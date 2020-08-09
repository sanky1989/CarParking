using System;
using Parking.Core.Abstractions;
using Parking.Core.Validators;

namespace Parking.Core.Implementations
{
    public class InputDateValidator : IValidator<string>
    {
        public Validation IsValid(string input)
        {
            var retVal = new Validation() { IsValid = true };

            try
            {
                if (Convert.ToDateTime(input) == default(DateTime))
                {
                    retVal.IsValid = false;
                    retVal.ErrorMessage = "Date Entered is Invalid. Please retry it again." ;
                }
            }
            catch (Exception ex)
            {
                retVal.IsValid = false;
                retVal.ErrorMessage = ex.Message;
            }
            return retVal;//Return Validation
        }

       
    }
}
