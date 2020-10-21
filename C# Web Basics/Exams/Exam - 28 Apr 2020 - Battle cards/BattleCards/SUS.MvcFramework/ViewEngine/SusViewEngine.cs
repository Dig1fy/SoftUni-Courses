
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Emit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace SUS.MvcFramework.ViewEngine
{
    public class SusViewEngine : IViewEngine
    {
        public string GetHtml(string templateCode, object viewModel, string user)
        {
            //1) Generate c# code from the template
            string csharpCode = GenerateCSharpFromTemplate(templateCode, viewModel);
            //2) Then, we get executable object (IL -> exe)
            IView executableObject = GenerateExecutableCode(csharpCode, viewModel);
            //3) 
            string html = executableObject.ExecuteTemplate(viewModel, user);

            return html;
        }
        private string GenerateCSharpFromTemplate(string templateCode, object viewModel)
        {
            //Handling the Model 
            string typeOfModel = "object";
            if (viewModel != null)
            {
                //We need to explicitly check if it's generic (List<xxx>) since List<int>.GetType().FullName returns List'1" ... default behavior
                if (viewModel.GetType().IsGenericType)
                {
                    var modelName = viewModel.GetType().FullName;
                    var genericArguments = viewModel.GetType().GenericTypeArguments;
                    typeOfModel = modelName.Substring(0, modelName.IndexOf('`'))
                        //will return for example Dictionary<int, string>, instead of Dictionary'2
                        + "<" + string.Join(",", genericArguments.Select(x => x.FullName)) + ">";
                }
                else
                {
                    typeOfModel = viewModel.GetType().FullName;
                }
            }

            string csharpCode = @"
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using SUS.MvcFramework.ViewEngine;
namespace ViewNamespace
{
    public class ViewClass : IView
    {
        public string ExecuteTemplate(object viewModel, string user)
        {
            var User = user;
            var Model = viewModel as " + typeOfModel + @";
            var html = new StringBuilder();
            " + GetMethodBody(templateCode) + @"
            return html.ToString().TrimEnd();
        }
    }
}
";

            return csharpCode;
        }

        private object GetMethodBody(string templateCode)
        {
            Regex csharpCodeRegex = new Regex(@"[^\""\s&\'\<]+");
            var supportedOperators = new List<string> { "for", "while", "if", "else", "foreach" };
            StringBuilder csharpCode = new StringBuilder();
            StringReader sr = new StringReader(templateCode);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                if (supportedOperators.Any(x => line.TrimStart().StartsWith("@" + x)))
                {
                    var atSignLocation = line.IndexOf("@");
                    line = line.Remove(atSignLocation, 1);
                    csharpCode.AppendLine(line);
                }
                else if (line.TrimStart().StartsWith("{") ||
                    line.TrimStart().StartsWith("}"))
                {
                    csharpCode.AppendLine(line);
                }
                else
                {
                    csharpCode.Append($"html.AppendLine(@\"");

                    //If we have many "@" on the same line
                    while (line.Contains("@"))
                    {
                        var atSignLocation = line.IndexOf("@");
                        var htmlBeforeAtSign = line.Substring(0, atSignLocation);
                        csharpCode.Append(htmlBeforeAtSign.Replace("\"", "\"\"") + "\" + ");
                        //We will need to separate C# code from the next special symbol (@<^&| . etc.)

                        var lineAfterAtSign = line.Substring(atSignLocation + 1);
                        var code = csharpCodeRegex.Match(lineAfterAtSign).Value;
                        csharpCode.Append(code + " + @\"");

                        //After cutting the code (before the next special symbol and after the "@"), we need to adjust the line with the current consistence
                        line = lineAfterAtSign.Substring(code.Length);
                    }


                    csharpCode.AppendLine(line.Replace("\"", "\"\"") + "\");");

                }
            }

            return csharpCode.ToString();
        }

        //Generate instance with Reflection
        private IView GenerateExecutableCode(string csharpCode, object viewModel)
        {
            //Using Roslyn: NugetPackage  Microsoft.CodeAnalysis.CSharp
            // C# -> executable -> IView -> ExecuteTemplate()

            var compileResult = CSharpCompilation.Create("ViewAssembly")  // Name of our new Assembly
                .WithOptions(new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary)) // Type of our project (Console app, DLL, etc)
                .AddReferences(MetadataReference.CreateFromFile(typeof(object).Assembly.Location)) // our base refference location
                .AddReferences(MetadataReference.CreateFromFile(typeof(IView).Assembly.Location)); //SUS.MvcFramework

            if (viewModel != null)
            {
                //In case the type of our view model is generic, we add all references of the type 
                if (viewModel.GetType().IsGenericType)
                {
                    //get an array of the generic type arguments
                    var genericArguments = viewModel.GetType().GenericTypeArguments;
                    foreach (var genericArg in genericArguments)
                    {
                        compileResult = compileResult
                            .AddReferences(MetadataReference.CreateFromFile(genericArg.Assembly.Location));
                    }
                }

                compileResult = compileResult
                    .AddReferences(MetadataReference.CreateFromFile(viewModel.GetType().Assembly.Location));
            }

            //We need to load all libraries from .Net standard  
            var libraries = Assembly.Load(
                new AssemblyName("netstandard")).GetReferencedAssemblies();
            foreach (var library in libraries)
            {
                compileResult = compileResult
                    .AddReferences(MetadataReference.CreateFromFile(
                        Assembly.Load(library).Location));
            }

            //Now we add the code
            compileResult = compileResult.AddSyntaxTrees(SyntaxFactory.ParseSyntaxTree(csharpCode));

            //We don't need a dll so we will emit into memory stream 
            using (MemoryStream memoryStream = new MemoryStream())
            {
                EmitResult emitResult = compileResult.Emit(memoryStream);

                //Check if we have any errors in our body method (csharpCode)
                if (!emitResult.Success)
                {
                    //Compile errors!!!!!
                    return new ErrorView(emitResult.Diagnostics
                        .Where(x => x.Severity == DiagnosticSeverity.Error)
                        .Select(x => x.GetMessage()), csharpCode);
                }

                //If we start reading from the stream, we will start at the current position of the head. 
                //Basically, we need to reset the head position, starting from the begining of the stream.

                try
                {
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    var byteAssembly = memoryStream.ToArray();
                    var assembly = Assembly.Load(byteAssembly);
                    var viewType = assembly.GetType("ViewNamespace.ViewClass");
                    var instance = Activator.CreateInstance(viewType);
                    return (instance as IView)
                        ?? new ErrorView(new List<string> { "Instance is null!" }, csharpCode);
                }
                catch (Exception ex)
                {
                    return new ErrorView(new List<string> { ex.ToString() }, csharpCode);
                }
            }
        }
    }
}
