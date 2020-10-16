using BattleCards.Controllers;
using BattleCards.Data;
using BattleCards.Services;
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

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            //In ASP Core -> AddSingleton(once instance with "new" till we close the app), AddTransient(give instance with "new" every time), AddScoped
            serviceCollection.Add<IUsersService, UsersService>();
            serviceCollection.Add<ICardsService, CardsService>();
        }
        public void Configure(List<Route> routeTable)
        {
            //Apply all pending migrations to the database. It also ensures that the db has been created
            new ApplicationDbContext().Database.Migrate();
        }        
    }
}
