using Parking.Core.DTO;
using Parking.Service.NormalService;
using Parking.Service.Special_Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Service.Calculator
{
    public class CalculatorService : ICalculatorService
    {
        private  ISpecialService _specialRateService;
        private  INormalService _normalRateService;

        public CalculatorService(ISpecialService specialService, INormalService normalService)
        {
            _specialRateService = specialService;
            _normalRateService = normalService;
        }

        public async Task<ParkingRateDto> Calculate(TimerDto input)
        {
            var specialRates = await _specialRateService.GetAllAsync();
            var normalRates = await _normalRateService.GetAllAsync();
            var retVal = new ParkingRateDto();

            var resultSpecial = _specialRateService.Calculate(specialRates, input.Entry, input.Exit);
            retVal = resultSpecial;

            var resultNormal = _normalRateService.Calculate(normalRates, input.Entry, input.Exit);
            //Return correct result
            if (resultNormal.Price > 0 && (retVal.Price == 0 || retVal.Price > resultNormal.Price))
            {
                retVal.Name = resultNormal.Name;
                retVal.Price = resultNormal.Price;
            }
            return retVal;
        }
    }
}
