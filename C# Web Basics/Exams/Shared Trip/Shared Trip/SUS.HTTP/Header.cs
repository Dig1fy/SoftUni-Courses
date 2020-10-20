using System;

namespace SUS.HTTP
{
    public class Header
    {
        //We make 2nd constructor to make easy pass of the initializing with name/value
        public Header(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }
        public Header(string headerLine)
        {
            //Example->     Accept-Encoding: gzip, deflate, br, :: :,
            //We split the line to 2 parts ( otherwise ":: :" will be a valid header part)
            var headerParts = headerLine.Split(new string[] { ": " }, 2, StringSplitOptions.None);
            this.Name = headerParts[0];
            this.Value = headerParts[1];
        }
        public string Name { get; set; }

        public string Value { get; set; }

        public override string ToString()
        {
            return $"{this.Name}: {this.Value}";
        }
    }
}