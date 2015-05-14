using System;
using Autofac.Interface;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using Autofac.Common;
using System.Threading;

namespace Autofac.Demo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            #region SameFolder
            //ContainerBuilder builer = new ContainerBuilder();
            //builer.RegisterType<Shouter>().Named<IShout>("Normal");
            //property injection by lambda
            // builer.Register(c => new Wrapper() { Shoutter=  c.ResolveNamed<IShout>("Normal") });
            //property injection by event
            // builer.Register(c => new Wrapper()).OnActivated(e => e.Instance.Shoutter = e.Context.ResolveNamed<IShout>("Normal"));
            // builer.RegisterAssemblyTypes(Assembly.GetExecutingAssembly());
            //builer.RegisterType<Wrapper>().WithParameter(new NamedParameter("shout",)
            //using (IContainer container = builer.Build())
            //{
            //    var shout = container.ResolveNamed<IShout>("Normal");
            //    Console.WriteLine(shout.Shout(Console.ReadLine()));
            //    var wrapper = container.Resolve<Wrapper>();
            //    Console.WriteLine(wrapper.Shoutter.Shout(Console.ReadLine()));
            //}
            #endregion

            Bootstrapper.Register();
            dynamic caller = Bootstrapper.AppContainer.Resolve<IShout>();
            string val = Console.ReadLine();
            Console.WriteLine(caller.Shout(val));
            Console.WriteLine(CacheMgr.Container.GetData(val));
            Thread.Sleep(7000);
            Console.WriteLine(CacheMgr.Container.GetData(val)??"null");
            Console.ReadKey();
        }
    }
}