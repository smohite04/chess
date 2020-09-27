using CommonServiceLocator;
using Microsoft.Extensions.DependencyInjection;
using StructureMap;
using System;
using System.Collections.Generic;

namespace Chess.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = SetupContainer();
            var option = OptionHelper.GetOptionToBeExecuted();
            var optionHandler = GetOptionHandler(container, option);
            optionHandler.ExecuteOption();
            Console.WriteLine("Thank You..!!");
        }

        private static IOptionhandler GetOptionHandler(Container container, string option)
        {
            var serviceProvider = container.GetInstance<IServiceProvider>();
            var locator = serviceProvider.GetService<IServiceLocator>();
            var optionHandler = locator.GetInstance<IOptionhandler>(option);
            return optionHandler;
        }

        private static Container SetupContainer()
        {
            // add the framework services
            var services = new ServiceCollection();

            // add StructureMap
            var container = new Container();
            container.Configure(config =>
            {
                config.Scan(_ =>
                {
                    _.AssemblyContainingType(typeof(Program));
                    _.WithDefaultConventions();
                });
                // Populate the container using the service collection
                config.AddRegistry<WebRegistry>();
                config.Populate(services);
            });
            return container;
        }      
    }
}
