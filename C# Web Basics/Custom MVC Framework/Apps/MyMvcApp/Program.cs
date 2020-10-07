using MyMvcApp.Controllers;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyMvcApp
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
