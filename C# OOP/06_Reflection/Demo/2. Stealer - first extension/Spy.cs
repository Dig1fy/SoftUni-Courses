namespace Stealer
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class Spy
    {
        public string StealFieldInfo(string investigationClass, params string[] fieldsToInvestigate)
        {
            Type classType = Type.GetType($"Stealer.{investigationClass}");

            FieldInfo[] classFields = classType.GetFields(
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);

            var stringBuilder = new StringBuilder();

            Object classInstance = Activator.CreateInstance(classType, new object[] { });

            stringBuilder.AppendLine($"Class under investigation: {investigationClass}");

            var sortedClassFields = classFields.Where(x => fieldsToInvestigate.Contains(x.Name));

            foreach (var field in sortedClassFields)
            {
                stringBuilder.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return stringBuilder.ToString().Trim();
        }

        public string AnalyzeAcessModifiers (string investigateClassName)
        {
            Type classType = Type.GetType($"Stealer.{investigateClassName}");

            FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);

            MethodInfo[] classPublicMethods = classType.GetMethods(BindingFlags.Public | BindingFlags.Instance);

            MethodInfo[] classNonPublicMethods = classType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            StringBuilder stringBuilder = new StringBuilder();

            foreach (var field in classFields)
            {
                stringBuilder.AppendLine($"{field.Name} must be private!");
            }
            foreach (var publicMethod in classPublicMethods)
            {
                stringBuilder.AppendLine($"{publicMethod.Name} have to be public!");
            }
            foreach (var nonPublicMethod in classNonPublicMethods)
            {
                stringBuilder.AppendLine($"{nonPublicMethod.Name} have to be private!");
            }

            return stringBuilder.ToString().Trim();
        }
    }
}
