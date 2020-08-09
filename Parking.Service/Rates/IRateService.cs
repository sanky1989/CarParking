using System;
using System.Collections.Generic;
using System.Text;
using Parking.Core.DTO;

namespace Parking.Service.Rates
{
    public interface IRateService<T>
    {
        ParkingRateDto Calculate(IEnumerable<T> rates, DateTime start, DateTime end);
    }
}
