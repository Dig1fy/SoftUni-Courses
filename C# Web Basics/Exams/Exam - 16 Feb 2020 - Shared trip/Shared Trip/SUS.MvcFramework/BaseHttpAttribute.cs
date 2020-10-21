using SUS.HTTP.Enums;
using System;

namespace SUS.MvcFramework
{
    //When we automatically generate routes, we can do it only if we know the http method - get/post. Therefore, we will achieve it using attributes
    //Also, when implementing custom attributes, we must inherit "Attribute" which comes from System;
    public abstract class BaseHttpAttribute : Attribute
    {
        //We've set a default Url but If we want go explicitly give an url to the attribute-> [HttpPost("cards/all")]
        public string Url { get; set; }

        public abstract HttpMethod Method { get; }
    }
}
