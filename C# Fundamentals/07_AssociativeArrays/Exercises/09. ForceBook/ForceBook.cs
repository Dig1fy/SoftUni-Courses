using System;
using System.Collections.Generic;
using System.Linq;

namespace ForceBook
{
    class Program
    {
        static void Main()
        {
            string input = string.Empty;
            var allUsers = new Dictionary<string, string>();
            
            while ((input = Console.ReadLine())!= "Lumpawaroo")
            {
                if (input.Contains('|'))
                {
                    string[] inputArgs = input.Split('|')
                        .Select(s => s.Trim())
                        .ToArray();

                    if (!allUsers.ContainsKey(inputArgs[1]))
                    {
                        allUsers.Add(inputArgs[1], inputArgs[0]);
                    }
                }
                else
                {
                    string[] tokens = input
                        .Split("->".ToCharArray())
                        .Select(s => s.Trim())
                        .ToArray();

                    if (allUsers.ContainsKey(tokens[0]))
                    {
                        allUsers[tokens[0]] = tokens[2];
                        Console.WriteLine($"{tokens[0]} joins the {tokens[2]} side!");
                    }
                    else
                    {
                        allUsers.Add(tokens[0], tokens[2]);
                        Console.WriteLine($"{tokens[0]} joins the {tokens[2]} side!");
                    }
                }
            }

            foreach (var side in allUsers.GroupBy(x => x.Value).OrderByDescending(t => t.Count()).ThenBy(a => a.Key))
            {
                Console.WriteLine($"Side: { side.Key}, Members: {side.Count()} ");

                foreach (var user in side.OrderBy(d => d.Key))
                {
                    Console.WriteLine($"! {user.Key}");
                }
            }
        }
    }
}