using CommonServiceLocator;
using StructureMap;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Chess.Host
{
    public class StructureMapServiceLocator : IServiceLocator
    {
        private readonly IContainer _container;

        public StructureMapServiceLocator(IContainer container)
        {
            _container = container;
        }

        public IEnumerable<object> GetAllInstances(Type serviceType)
        {
            var output = _container.GetAllInstances(serviceType);
            return Convert(output);

        }

        public IEnumerable<TService> GetAllInstances<TService>()
        {
                return _container.GetAllInstances<TService>();
            
        }

        public object GetInstance(Type serviceType)
        {
                return _container.GetInstance(serviceType);
            
           
        }

        public object GetInstance(Type serviceType, string key)
        {

            if (string.IsNullOrWhiteSpace(key))
                return _container.GetInstance(serviceType);
            return _container.GetInstance(serviceType, key);


        }

        public TService GetInstance<TService>()
        {
            return _container.GetInstance<TService>();
        }

        public TService GetInstance<TService>(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                return _container.GetInstance<TService>();
            return _container.GetInstance<TService>(key);

        }

        public object GetService(Type serviceType)
        {
            return _container.TryGetInstance(serviceType);
        }

        private static IEnumerable<object> Convert(IEnumerable enumerable)
        {
            return enumerable.Cast<object>().ToList();
        }
    }
}
