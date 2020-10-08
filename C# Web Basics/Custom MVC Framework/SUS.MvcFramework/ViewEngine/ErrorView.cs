using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SUS.MvcFramework.ViewEngine
{
    //When we generate html from the csharpCode and there are compile errors, this view will be called to give more detailed info about the errors
    public class ErrorView : IView
    {
        private readonly IEnumerable<string> errors;
        private readonly string csharpCode;

        public ErrorView(IEnumerable<string> errors, string csharpCode)
        {
            this.errors = errors;
            this.csharpCode = csharpCode ?? throw new System.ArgumentNullException(nameof(csharpCode));
        }

        public string ExecuteTemplate(object viewModel)
        {
            var html = new StringBuilder();
            html.AppendLine($"<h1>View compile {this.errors.Count()} errors:</h1><ul>");

            foreach (var error in this.errors)
            {
                html.AppendLine($"<li>{error}</li>");
            }

            html.AppendLine($"</ul><pre>{csharpCode}</pre>");

            return html.ToString();
        }
    }
}
