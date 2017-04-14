using System;

namespace AttributePropertyValidation.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class RequiredAttribute : Attribute
    {

    }
}
