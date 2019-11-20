using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyUsers
{
    class Program
    {
        static void Main()
        {
            var companies = new Dictionary<string, List<string>>();
            var command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                var commandArr = command
                    .Split(" -> ").ToArray();

                var currentCompany = commandArr[0];
                var currentID = commandArr[1];

                if (!companies.ContainsKey(currentCompany))
                {
                    companies[currentCompany] = new List<string>();
                }
                
                if (!companies[currentCompany].Contains(currentID))
                {
                    companies[currentCompany].Add(currentID);
                }
            }

            companies = companies
                .OrderBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var company in companies)
            {
                Console.WriteLine(company.Key);

                foreach (var ID in company.Value)
                {
                    Console.WriteLine($"-- {ID}");
                }
            }
        }
    }
}