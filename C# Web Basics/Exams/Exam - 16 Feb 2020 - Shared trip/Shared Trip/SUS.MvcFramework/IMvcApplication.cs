using System.Collections.Generic;

namespace SUS.MvcFramework
{
    public interface IMvcApplication
    {
        //Set dependencies
        void ConfigureServices(IServiceCollection serviceCollection);

        //Set additional settings
        void Configure(List<Route> routeTable);
    }
}
