namespace ValidationAttributes
{
    using System;

    //[AttributeUsage(AttributeTargets.Method|AttributeTargets.Property)]
    public abstract class MyValidationAttribute : Attribute
    {
        public abstract bool IsValid(object obj);
    }
}
