using System;

namespace SUS.MvcFramework
{
    public interface IServiceCollection
    {
        //Here's our dependency container -> .Add<IUsersService, UsersService>
        void Add<TSource, TDestination>();

        object CreateInstance(Type type);
    }
}
