using Microsoft.EntityFrameworkCore;
using SharedTrip.Data;
using SharedTrip.Services;
using SUS.MvcFramework;
using System.Collections.Generic;

namespace SharedTrip
{
    public class StartUp : IMvcApplication
    {
        public void Configure(List<Route> routeTable)
        {
            new ApplicationDbContext().Database.Migrate();
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<ITripsService, TripsService>();
            serviceCollection.Add<IUsersService, UsersService>();
        }
    }
}
