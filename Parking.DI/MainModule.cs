using System;
using Autofac;
namespace Parking.DI
{
    public class MainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterModule<InfrastructureModule>();
            builder.RegisterModule<DomainModule>();
            builder.RegisterModule<ApplicationModule>();
        }
    }
}
