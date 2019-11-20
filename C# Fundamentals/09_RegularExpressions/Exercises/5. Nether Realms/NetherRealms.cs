using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace NetherRealms
{
    class Program
    {
        static void Main()
        {
            var listOfDemons = Console.ReadLine().Split(new[] { ',', '\t', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            var demonsDamage = new Dictionary<string, double>();
            var demonsHealth = new Dictionary<string, int>();
            var dmgPattern = @"[-+]?\d+[.]?[-+]?\d*";

            for (int i = 0; i < listOfDemons.Length; i++)
            {
                var currentDamage = 0.0;
                var currentHealth = 0;
                var currentDemon = listOfDemons[i];
                var matches = Regex.Matches(listOfDemons[i], dmgPattern);
                var demon = listOfDemons[i];

                currentHealth = GetDemonsHealth(demon, i, currentHealth);
                currentDamage = GetDemonsDamage(demon, i, currentDamage, matches);

                demonsDamage.Add(currentDemon, currentDamage);
                demonsHealth.Add(currentDemon, currentHealth);
            }

            demonsDamage = demonsDamage.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (var demon in demonsDamage)
            {
                foreach (var health in demonsHealth.Where(x => x.Key == demon.Key))
                {
                    Console.WriteLine($"{demon.Key} - {health.Value} health, {demon.Value:f2} damage");
                }
            }
        }        

        private static int GetDemonsHealth(string listOfDemons, int i, int currentHealth)
        {
            for (int l = 0; l < listOfDemons.Length; l++)
            {
                if (!char.IsDigit(listOfDemons[l]) && listOfDemons[l] != '+' && listOfDemons[l] != '-' &&
                    listOfDemons[l] != '*' && listOfDemons[l] != '/' && listOfDemons[l] != '.')
                {
                    var currentDIgit = listOfDemons[l];
                    currentHealth += listOfDemons[l];
                }
            }

            return currentHealth;
        }

        private static double GetDemonsDamage(string listOfDemons, int i, double currentDamage, MatchCollection matches)
        {
            foreach (Match dmg in matches)
            {
                currentDamage += double.Parse(dmg.Value);
            }
            for (int j = 0; j < listOfDemons.Length; j++)
            {
                if (currentDamage > 0)
                {
                    if (listOfDemons[j] == '*')
                    {
                        currentDamage *= 2;
                    }
                    else if (listOfDemons[j] == '/')
                    {
                        currentDamage /= 2;
                    }
                }
            }

            return currentDamage;
        }
    }
}
