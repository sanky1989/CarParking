using Autofac;
using Autofac.Core;
using Parking.Application.Application;
using Parking.Core;
using Parking.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Parking.DI
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            /* Application Services */
            builder.RegisterType<ApplicationService>()
                .As<IApplicationService>()
                .WithParameter(
                    new ResolvedParameter(
                        (pi, ctx) => pi.ParameterType == typeof(IValidator<string>),
                        (pi, ctx) => ctx.ResolveKeyed<IValidator<string>>(CONSTANTS.APPLICATION_TYPES.CONSOLE)))
                .SingleInstance();
        }
    }
}
