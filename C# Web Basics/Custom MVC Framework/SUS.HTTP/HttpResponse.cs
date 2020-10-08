using SUS.HTTP.Enums;
using SUS.HTTP.GlobalConstants;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using System.Reflection;
using System.Text;

namespace SUS.HTTP
{
    public class HttpResponse
    {        
        public HttpResponse(HttpStatusCode statusCode)
        {
            this.StatusCode = statusCode;
            this.Headers = new List<Header>();

            this.Cookies = new List<Cookie>();
        }
        public HttpResponse(string contentType, byte[] body, HttpStatusCode statusCode = HttpStatusCode.Ok)
        {
            if (body == null)
            {
                throw new ArgumentNullException(nameof(body));
            }

            this.StatusCode = statusCode;
            this.Body = body;
            //There are some mandatory headers so we add them when initializing;
            this.Headers = new List<Header>
            {
                { new Header("Content-Type", contentType) },
                { new Header("Content-Length", body.Length.ToString()) }
            };

            this.Cookies = new List<Cookie>();

        }
        public HttpStatusCode StatusCode { get; set; }

        public ICollection<Header> Headers { get; set; }

        public ICollection<Cookie> Cookies { get; set; }

        public byte[] Body { get; set; }

        public override string ToString()
        {
            //We need to build the http response here
            var responseBuilder = new StringBuilder();
            responseBuilder.Append($"HTTP/1.1 {(int)this.StatusCode} {this.StatusCode} {HTTPConstants.NewLine}");

            foreach (var cookie in this.Cookies)
            {
                responseBuilder.Append($"Set-Cookie: {cookie.ToString()} {HTTPConstants.NewLine}");
            }

            foreach (var header in this.Headers)
            {
                //In Header class, we the ToString() is overriden so we use it here (it returns name:value)
                responseBuilder.Append(header.ToString() + HTTPConstants.NewLine);
            }

            //Once we've finished with all headers, we need to append new line to tell the browser that it should stop listening
            responseBuilder.Append(HTTPConstants.NewLine);

            return responseBuilder.ToString();
        }
    }
}
