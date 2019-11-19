using Articles;
using System;
using System.Linq;

namespace Article
{
    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine()
                .Split(", ")
                .ToArray();

            int number = int.Parse(Console.ReadLine());
            string title = input[0];
            string content = input[1];
            string author = input[2];

            Article currentArticle = new Article(title, content, author);

            for (int i = 1; i <= number; i++)
            {
                string[] command = Console.ReadLine().Split(": ").ToArray();
                string action = command[0];
                string newContent = command[1];

                if (action == "Edit")
                {
                    currentArticle.EditTheInput(newContent);
                }

                else if (action == "ChangeAuthor")
                {
                    currentArticle.ChangeAuthor(newContent);
                }

                else if (action == "Rename")
                {
                    currentArticle.RenameTitle(newContent);
                }
            }

            Console.WriteLine($"{currentArticle.Title} - {currentArticle.Content}: {currentArticle.Author}");
        }
    }
}