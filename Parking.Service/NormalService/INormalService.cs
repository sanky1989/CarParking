using Parking.Core.Abstractions;
using Parking.Model;
using Parking.Service.Rates;
using System;
using System.Collections.Generic;
using System.Text;

namespace Parking.Service.NormalService
{
    public interface INormalService : IDomainService<NormalRates>, IRateService<NormalRates>
    {
    }
}
