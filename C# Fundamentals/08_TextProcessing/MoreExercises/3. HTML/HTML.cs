using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HTML
{
    class Program
    {
        static void Main()
        {
            var title = Console.ReadLine();
            var content = Console.ReadLine();
            var builder = new StringBuilder();
            builder.Append($"<h1>\n{title}\n</h1>");
            builder.Append($"\n<article>\n{content}\n</article>");

            var comments = string.Empty;

            while ((comments = Console.ReadLine()) != "end of comments")
            {
                builder.Append($"\n<div>\n{comments}\n</div>");
            }

            var result = builder.ToString();
            Console.WriteLine(result);
        }
    }
}
