namespace ValidationAttributes
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            PropertyInfo[] objProperties = obj.GetType()
                .GetProperties();

            foreach (var propertyInfo in objProperties)
            {
                IEnumerable<MyValidationAttribute> propertyAttributes = propertyInfo.GetCustomAttributes()
                    .Where(x => x is MyValidationAttribute)
                    .Cast<MyValidationAttribute>();

                foreach (var propAttribute in propertyAttributes)
                {
                    bool checkTheResult = propAttribute.IsValid(propertyInfo.GetValue(obj));

                    if (!checkTheResult)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
