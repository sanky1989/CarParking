using System;
using Parking.Core.Abstractions;
using Parking.Core.DTO;

namespace Parking.Core.Validators.Implementations
{
    public class InputDatesValidator : IValidator<TimerDto>
    {
        public Validation IsValid(TimerDto input)
        {
            //Initialize
            var retVal = new Validation() { IsValid = true };


            var entryTime = Convert.ToDateTime(input.Entry);
            var exitTime = Convert.ToDateTime(input.Exit);
            if (exitTime <= entryTime)
            { //Validate Time
                retVal.IsValid = false;
                retVal.ErrorMessage = "Exit time must be later than Entry Time.";
            }
            return retVal;
        }
    }
}
