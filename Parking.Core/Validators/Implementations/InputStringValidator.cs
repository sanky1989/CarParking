using Parking.Core.Abstractions;

namespace Parking.Core.Validators.Implementations
{
    public class InputStringValidator : IValidator<string>
    {
        public Validation IsValid(string input)
        {
            var result = new Validation() { IsValid = true };
            if (string.IsNullOrEmpty(input))
            {
                result.IsValid = false;
                result.ErrorMessage = "Input Value is Required.";
            }
            //Return Validation.
            return result;
        }
    }
}
