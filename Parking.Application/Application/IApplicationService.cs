using Parking.Core.DTO;
using Parking.Core.Validators;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Application.Application
{
    public interface IApplicationService
    {
        Validation ValidateInput(IList<string> input, out TimerDto timer);
        Validation ValidateInput( TimerDto timer);
        Task<string> ProcessAsync(TimerDto input);
    }
}
