using Microsoft.EntityFrameworkCore;
using SULS.Data;
using SULS.Services;
using SUS.MvcFramework;
using System.Collections.Generic;

namespace SULS
{
    public class StartUp : IMvcApplication
    {
        public void Configure(List<Route> routeTable)
        {
            new ApplicationDbContext().Database.Migrate();
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            //Dependency container
            serviceCollection.Add<IUsersService, UsersService>();
            serviceCollection.Add<IProblemsService, ProblemsService>();
            serviceCollection.Add<ISubmissionsService, SubmissionsService>();
        }
    }
}
