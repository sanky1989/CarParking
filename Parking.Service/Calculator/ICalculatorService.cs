using System;
using System.Collections.Generic;
using System.Text;
using Parking.Core.DTO;
using System.Threading.Tasks;
namespace Parking.Service.Calculator
{
    public interface ICalculatorService
    {
        Task<ParkingRateDto> Calculate(TimerDto input);
    }
}
