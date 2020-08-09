using Autofac;
using Parking.Core;
using Parking.Core.Abstractions;
using Parking.Core.DTO;
using Parking.Core.Implementations;
using Parking.Core.Validators.Implementations;
using Parking.Model;
using Parking.Repository.Interface;
using Parking.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Parking.DI
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

           //Validation
            builder.RegisterType<InputStringValidator>() .As<IValidator<string>>()
                .Keyed<IValidator<string>>(CONSTANTS.APPLICATION_TYPES.CONSOLE);

            builder.RegisterType<InputDateValidator>().As<IValidator<string>>()
                .Keyed<IValidator<string>>(CONSTANTS.APPLICATION_TYPES.CONSOLE);

            builder.RegisterType<InputDatesValidator>()
                .As<IValidator<TimerDto>>();

           //Special Repository
            builder.RegisterType<SpecialRepository>().As<IRepository<SpecialRates>>()//Special Model
                .As<ISpecialRepository>()
                .SingleInstance();

            builder.RegisterType<NormalJsonRepository>().As<IRepository<NormalRates>>()//Normal Model
                .As<INormalRepository>()
                .SingleInstance();
        }
    }
}
