using SUS.HTTP;
using SUS.HTTP.Enums;
using System;

namespace SUS.MvcFramework
{
    public class Route
    {
        public Route(string path, HttpMethod method, Func<HttpRequest, HttpResponse> action)
        {
            this.Path = path;
            this.Action = action;
            this.Method = method;
        }
        
        public HttpMethod Method { get; set; }

        public string Path { get; set; }

        public Func<HttpRequest, HttpResponse> Action { get; set; }
    }
}
