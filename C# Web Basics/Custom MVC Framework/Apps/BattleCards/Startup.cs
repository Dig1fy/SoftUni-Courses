using BattleCards.Controllers;
using BattleCards.Data;
using Microsoft.EntityFrameworkCore;
using SUS.HTTP.Enums;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleCards               //TO DOOOOOOOOOOOOOOOOOOOOOOO - Implement logic for IndexViewModel
                                    //1:39:00 video
{
    public class Startup : IMvcApplication
    {

        public void ConfigureServices()
        {

        }
        public void Configure(List<Route> routeTable)
        {
            //Apply all pending migrations to the database. It also ensures that the db has been created
            new ApplicationDbContext().Database.Migrate();
        }
    }
}
