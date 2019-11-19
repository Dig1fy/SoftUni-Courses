using System;
using System.Collections.Generic;
using System.Linq;

namespace Articles2_0
{
    class Program
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());


            List<Article> finalList = new List<Article>();

            for (int i = 1; i <= number; i++)
            {
                string[] input = Console.ReadLine().Split(", ").ToArray();

                string title = input[0];
                string content = input[1];
                string author = input[2];

                Article currentArticle = new Article(title, content, author);
                finalList.Add(currentArticle);
            }

            string action = Console.ReadLine();

            if (action == "title")
            {
                finalList = finalList.OrderBy(x => x.Title).ToList();
            }

            else if (action == "content")
            {
                finalList = finalList.OrderBy(x => x.Content).ToList();
            }

            else if (action == "author")
            {
                finalList = finalList.OrderBy(x => x.Author).ToList();
            }

            Console.WriteLine(string.Join(Environment.NewLine, finalList));
        }
    }
}