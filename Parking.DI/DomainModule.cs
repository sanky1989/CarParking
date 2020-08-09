using Autofac;
using Parking.Core.Abstractions;
using Parking.Model;
using Parking.Service.Calculator;
using Parking.Service.NormalService;
using Parking.Service.Special_Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Parking.DI
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            /* Domain Services */
            builder.RegisterType<CalculatorService>().As<ICalculatorService>()
                .SingleInstance();

            builder.RegisterType<SpecialService>().As<IDomainService<SpecialRates>>()
                .As<ISpecialService>()
                .SingleInstance();

            builder.RegisterType<NormalService>().As<IDomainService<NormalRates>>()
                .As<INormalService>()
                .SingleInstance();
        }
    }
}
