using System;
using Parking.Core.DTO;
using Parking.Core.Validators;
using Autofac;
using Parking.DI;
using Parking.Application.Application;
using System.Collections.Generic;

namespace Parking.Console
{
    class Program
    {
        static void Main(string[] args)
        {


            var builder = new ContainerBuilder();
            builder.RegisterModule<MainModule>();
            IContainer container = builder.Build();

            var appService = container.Resolve<IApplicationService>();

            var timer = new TimerDto();
            var valid = new Validation();
            while (!valid.IsValid)
            {
                var input = new List<string>();

                System.Console.WriteLine("Enter Entry DateTime (DD/MM/YYYY HH:mm) : ");
                input.Add(System.Console.ReadLine());

                System.Console.WriteLine("Enter Exit DateTime  (DD/MM/YYYY HH:mm) : ");
                input.Add(System.Console.ReadLine());

                valid = appService.ValidateInput(input, out timer);
                if (!valid.IsValid)
                {
                    System.Console.WriteLine(valid.ErrorMessage);
                }
            }

            try
            {
                var response = appService.ProcessAsync(timer).Result;
                System.Console.WriteLine(response);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message + "\n");
            }

            System.Console.WriteLine("Press any key to exit...");
            System.Console.ReadLine();

        }
    }
}
