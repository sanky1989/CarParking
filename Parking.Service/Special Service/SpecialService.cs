using Parking.Core.Abstractions;
using Parking.Core.DTO;
using Parking.Model;
using Parking.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Service.Special_Service
{

    public class SpecialService : ISpecialService
    {
        private readonly IRepository<SpecialRates> _specialRepository;

        public SpecialService(ISpecialRepository specialRepository)
        {
            _specialRepository = specialRepository;
        }

        public async Task<IEnumerable<SpecialRates>> GetAllAsync()
        {
            return await _specialRepository.SelectAllAsync();
        }

        public ParkingRateDto Calculate(IEnumerable<SpecialRates> specialRates, DateTime start, DateTime end)
        {
            var result = new ParkingRateDto();

            foreach (var specialRate in specialRates)
            {
                // Entry
                bool isSpecial = (specialRate.Entry.Start <= start.TimeOfDay && 
                                    start.TimeOfDay <= specialRate.Entry.End) //Start between special entry and exit
                                  ||                                
                                  (specialRate.MaxDays > 0 && (specialRate.Entry.Start <= start.TimeOfDay &&
                                   start.TimeOfDay <= specialRate.Entry.End.Add(TimeSpan.FromDays(1)))     
                                   //More than 1 day and start time is betwen start and next days                         
                                   ||
                                  (specialRate.Entry.Start.Subtract(TimeSpan.FromDays(1)) <= start.TimeOfDay &&
                                   start.TimeOfDay <= specialRate.Entry.End));


                if (!specialRate.Entry.Days.Any(d => string.Equals(d, start.DayOfWeek.ToString(), StringComparison.InvariantCultureIgnoreCase)))
                {
                    isSpecial = false;
                }

                // Exit Date
                var maxExitDay = start.AddDays(specialRate.MaxDays);
                var maxExit = new DateTime(maxExitDay.Year, maxExitDay.Month, maxExitDay.Day, specialRate.Exit.End.Hours,
                    specialRate.Exit.End.Minutes, 0);
                if (end > maxExit)
                {
                    isSpecial = false;
                }

                if (!specialRate.Exit.Days.Any(d => string.Equals(d, end.DayOfWeek.ToString(), StringComparison.InvariantCultureIgnoreCase)))
                {
                    isSpecial = false;
                }

                // If more than max days, flat rate
                if ((end - start).Days > specialRate.MaxDays)
                {
                    isSpecial = false;
                }

                if (isSpecial)
                {
                    if (result.Price == 0 || result.Price > specialRate.TotalPrice)
                    {
                        result.Name = specialRate.Name;
                        result.Price = specialRate.TotalPrice;
                    }
                }
            }

            return result;

        }
    }
}
