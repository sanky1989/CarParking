using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parking.Core.DTO;
using Parking.DI;
using Parking.Service.Calculator;
using System;

namespace Parking.UnitTest
{
   
    [TestClass]
    public class ParkingRates
    {
        private ICalculatorService _calculatorService;
        [TestInitialize]
        public void Init()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<MainModule>();
            IContainer container = builder.Build();
            _calculatorService = container.Resolve<ICalculatorService>();
        }
        [TestMethod]
        public void EarlyBirdRates()
        {
            TimerDto Input = new TimerDto()
            {
                Entry = new DateTime(2020, 1, 1, 6, 0, 0),
                Exit = new DateTime(2020, 1, 1, 16, 0, 0)
            };
            ParkingRateDto retVal = new ParkingRateDto()
            {
                Name = "Early Bird",
                Price = 13
            };

            var result = _calculatorService.Calculate(Input).Result;
            Assert.AreEqual(retVal.Name, result.Name);
            Assert.AreEqual(retVal.Price, result.Price);
        }

        [TestMethod]
        public void NightRates()
        {
            TimerDto Input = new TimerDto()
            {
                Entry = new DateTime(2020, 1, 1, 18, 0, 0),
                Exit = new DateTime(2020, 1, 2, 6, 0, 0)
            };
            ParkingRateDto retVal = new ParkingRateDto()
            {
                Name = "Night Rate",
                Price = 6.5
            };

            var result = _calculatorService.Calculate(Input).Result;
            Assert.AreEqual(retVal.Name, result.Name);
            Assert.AreEqual(retVal.Price, result.Price);
        }


        [TestMethod]
        public void WeekendRates()
        {
            TimerDto Input = new TimerDto()
            {
                Entry = new DateTime(2020, 8, 1, 0, 0, 0),
                Exit = new DateTime(2020, 8, 3, 0, 0, 0)
            };
            ParkingRateDto retVal = new ParkingRateDto()
            {
                Name = "Weekend Rate",
                Price = 10
            };

            var result = _calculatorService.Calculate(Input).Result;
            Assert.AreEqual(retVal.Name, result.Name);
            Assert.AreEqual(retVal.Price, result.Price);
        }
    }
}
