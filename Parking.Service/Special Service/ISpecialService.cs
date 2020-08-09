using System;
using System.Collections.Generic;
using System.Text;
using Parking.Service.Rates;
using Parking.Core.Abstractions;
using Parking.Model;

namespace Parking.Service.Special_Service
{
    public interface ISpecialService : IDomainService<SpecialRates>, IRateService<SpecialRates>
    {
    }
}
