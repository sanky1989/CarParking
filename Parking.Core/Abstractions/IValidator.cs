using Parking.Core.Validators;

namespace Parking.Core.Abstractions
{
    public interface IValidator<in T>
    {
        //Implement Validation
        Validation IsValid(T input);
    }
}