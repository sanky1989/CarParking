using Parking.Core.Abstractions;
using Parking.Core.DTO;
using Parking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parking.Core;
using Parking.Repository.Interface;

namespace Parking.Service.NormalService
{
    public class NormalService : INormalService
    {
        private  IRepository<NormalRates> _normalRatesRepository;

        public NormalService(INormalRepository normalRatesRepository)
        {
            _normalRatesRepository = normalRatesRepository;
        }

        public async Task<IEnumerable<NormalRates>> GetAllAsync()
        {
            return await _normalRatesRepository.SelectAllAsync();
        }

        public ParkingRateDto Calculate(IEnumerable<NormalRates> normalRates, DateTime start, DateTime end)
        {
            var retVal = new ParkingRateDto() { Name = CONSTANTS.RATE.STANDARD };

            var resultNormalVariable = 0.0;
            var resultNormalFixed = 0.0;
            var isNormal = false;
            var TotalHours = (end - start).TotalHours;
            var maxNormalRate = normalRates.OrderBy(nr => nr.MaxHours).LastOrDefault();
            // More than max duration
            if (TotalHours >= maxNormalRate.MaxHours)
            {
                resultNormalVariable = Math.Floor(TotalHours / maxNormalRate.MaxHours) * maxNormalRate.Rate;
                TotalHours = TotalHours % maxNormalRate.MaxHours;
            }
            if (TotalHours > 0)
            {
                foreach (var normalRate in normalRates)
                {
                    if (!isNormal && TotalHours <= normalRate.MaxHours)
                    {
                        isNormal = true;
                        resultNormalFixed = normalRate.Rate;
                    }
                }
            }
            retVal.Price = resultNormalVariable + resultNormalFixed;//Total Price

            return retVal;
        }

      
    }
}
