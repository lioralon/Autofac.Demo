using Autofac.Impl;
using Autofac.Interface;

namespace Autofac.ModuleA
{
    public class ModuleEntry : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Shouter>().As<IShout>();
            builder.RegisterType<Wrapper>();
        }
    }
}