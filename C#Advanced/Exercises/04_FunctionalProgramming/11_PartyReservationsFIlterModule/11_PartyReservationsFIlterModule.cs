using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunctionalProgramming
{
    class Program
    {
        static List<string> names;
        static void Main()
        {
            names = Console.ReadLine().Split().ToList();
            var listOfFilters = new List<string>();
            FillAllFilters(listOfFilters);
            names = ExecuteAllFilters(listOfFilters, names);

            Console.WriteLine(string.Join(" ", names));
        }

        private static List<string> ExecuteAllFilters(List<string> listOfFilters, List<string> names)
        {
            foreach (var filter in listOfFilters)
            {
                var currentFilter = filter.Split(";")[0];
                var parameter = filter.Split(";")[1];

                switch (currentFilter)
                {
                    case "Starts with": names = names.Where(x => !x.StartsWith(parameter)).ToList(); break;
                    case "Ends with": names = names.Where(x => !x.EndsWith(parameter)).ToList(); break;
                    case "Length": names = names.Where(x => x.Length != int.Parse(parameter)).ToList(); break;
                    case "Contains": names = names.Where(x => !x.Contains(parameter)).ToList(); break;
                    default:
                        break;
                }
            }

            return names;
        }

        private static void FillAllFilters(List<string> listOfFilters)
        {
            var commandInfo = string.Empty;

            while ((commandInfo = Console.ReadLine()) != "Print")
            {
                var index = commandInfo.IndexOf(";");
                var action = commandInfo.Split(new char[] { ',', ' ' })[0];
                var currentFilter = commandInfo.Substring(index + 1);

                switch (action)
                {
                    case "Add":
                        listOfFilters.Add(currentFilter); break;
                    case "Remove":
                        listOfFilters.Remove(currentFilter); break;
                    default:
                        break;
                }
            }
        }
    }
}