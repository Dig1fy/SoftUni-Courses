using System;
using System.Collections.Generic;
using System.Linq;

namespace SUS.MvcFramework
{
    public class ServiceCollection : IServiceCollection
    {
        //Our StartUp will get IServiceCollection in it's constructor where will register all dependecies
        private Dictionary<Type, Type> DependencyContainer = new Dictionary<Type, Type>();
        public void Add<TSource, TDestination>()
        {
            this.DependencyContainer.Add(typeof(TSource), typeof(TDestination));
        }
        
        public object CreateInstance(Type type)
        {
            if (this.DependencyContainer.ContainsKey(type))
            {
                type = this.DependencyContainer[type];
            }

            //We want the constructor with less params
            var constructor = type.GetConstructors()
                .OrderBy(x => x.GetParameters().Count()).FirstOrDefault();

            var parameters = constructor.GetParameters();
            var parameterValues = new List<object>();

            //We need to create an instance for each of the constructor's params (recursively)
            foreach (var parameter in parameters)
            {
                var parameterValue = CreateInstance(parameter.ParameterType);
                parameterValues.Add(parameterValue);
            }

            //This has been implemented in ASP Core (dependency injection)
            var obj = constructor.Invoke(parameterValues.ToArray());
            return obj;
        }
    }
}
