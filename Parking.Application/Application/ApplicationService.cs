using Parking.Core.Abstractions;
using Parking.Core.DTO;
using Parking.Core.Validators;
using Parking.Service.Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Application.Application
{
    public class ApplicationService : IApplicationService
    {
        private ICalculatorService calService;
        private IEnumerable<IValidator<string>> _InputValidated;
        private IEnumerable<IValidator<TimerDto>> _datesValidators;

        //DI
        public ApplicationService(ICalculatorService calculatorService, IEnumerable<IValidator<string>> validators,
            IEnumerable<IValidator<TimerDto>> datesValidators
            )
        {
            calService = calculatorService;
            _InputValidated = validators;
            _datesValidators = datesValidators;
        }

        public async Task<string> ProcessAsync(TimerDto input)
        {
            var response = await calService.Calculate(input);//Calculate on the basis of input
            var retVal = "\nPackage : " + response.Name + "\nTOTAL COST : " + response.Price.ToString("C");
            return retVal;
        }


        public Validation ValidateInput(IList<string> input, out TimerDto timer)
        {
            timer = new TimerDto();

            foreach (var validator in _InputValidated)
            {
                foreach (var i in input)
                {
                    var r = validator.IsValid(i);
                    if (!r.IsValid)
                    {
                        return r;
                    }
                }
            }

            // Add them into the out objects
            timer.Entry = Convert.ToDateTime(input.ElementAt(0));
            timer.Exit = Convert.ToDateTime(input.ElementAt(1));

            foreach (var validator in _datesValidators)
            {
                var r = validator.IsValid(timer);
                if (!r.IsValid)
                {
                    return r;
                }
            }

            return new Validation() { IsValid = true };
        }

        public Validation ValidateInput( TimerDto timer)
        {
            foreach (var validator in _datesValidators)
            {
                var r = validator.IsValid(timer);
                if (!r.IsValid)
                {
                    return r;
                }
            }
            return new Validation() { IsValid = true };
        }
    }
}
