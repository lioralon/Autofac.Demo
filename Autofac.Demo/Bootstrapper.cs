using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Autofac.Core;

namespace Autofac.Demo
{
    public static class Bootstrapper
    {
        private static readonly ContainerBuilder autoFacBuilder = new ContainerBuilder();
        private static readonly object locker = new object();
        public static IContainer AppContainer { get;private set; }
       
        static Bootstrapper()
        {

        }
        public static void Register()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (String.IsNullOrWhiteSpace(path))
            {
                return;
            }
            path = string.Concat(path, "\\Modules");
            var assemblies = Directory.GetFiles(path, "Autofac.Module*.dll", SearchOption.TopDirectoryOnly)
                                      .Select(Assembly.LoadFrom);

            foreach (var assembly in assemblies)
            {
                var modules = assembly.GetTypes()
                                      .Where(p => typeof(IModule).IsAssignableFrom(p)
                                                  && !p.IsAbstract)
                                      .Select(p => (IModule)Activator.CreateInstance(p));

                foreach (var module in modules)
                {
                    autoFacBuilder.RegisterModule(module);
                }
            }
            lock (locker)
            {
                AppContainer = autoFacBuilder.Build();
                
            }
        }
    }
}