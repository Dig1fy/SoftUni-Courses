using BattleCards.Controllers;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BattleCards
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //The default port (defined in the CreateHost) is 80
            await Host.CreateHostAsync(new Startup(), 80);
        }
    }
}
