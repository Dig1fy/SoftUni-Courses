using SUS.HTTP.Enums;
using SUS.HTTP.GlobalConstants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SUS.HTTP
{
    public class HttpRequest
    {
        public HttpRequest(string requestString)
        {
            this.Headers = new List<Header>();
            this.Cookies = new List<Cookie>();

            //We split the entire request to chunks
            var lines = requestString.Split(new string[] { HTTPConstants.NewLine }, System.StringSplitOptions.None);
            var headerLine = lines[0];

            var headerParts = headerLine.Split(' ');
            this.Method = (HttpMethod)Enum.Parse(typeof(HttpMethod), headerParts[0], true); //true -> ignore case makes it case insensitive GET = Get (from the Enum keys)
            this.Path = headerParts[1];

            var bodyBuilder = new StringBuilder();
            
            var index = 1;
            var isInHeader = true;

            while (index < lines.Length)
            {
                var currentLine = lines[index];

                if (string.IsNullOrWhiteSpace(currentLine))
                {
                    isInHeader = false;
                    index++;
                    continue;
                }

                if (isInHeader)
                {
                    this.Headers.Add(new Header(currentLine));
                }
                else
                //Body
                {
                    bodyBuilder.AppendLine(currentLine);
                }

                index++;
            }

            if (this.Headers.Any(x=>x.Name == HTTPConstants.RequestCookieHeader))
            {
                var coockiesAsString = this.Headers.FirstOrDefault(x=>x.Name == HTTPConstants.RequestCookieHeader).Value;

                var cookies = coockiesAsString.Split(new string[] { "; " }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var cookie in cookies)
                {
                    this.Cookies.Add(new Cookie(cookie));
                }

            }

            this.Body = bodyBuilder.ToString();
        }

        public string Path { get; set; }

        public HttpMethod Method { get; set; }

        public ICollection<Header> Headers { get; set; }

        public ICollection<Cookie> Cookies { get; set; }

        public string Body { get; set; }

    }
}
