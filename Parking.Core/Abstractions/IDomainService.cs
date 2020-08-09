using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parking.Core.Abstractions
{
    public interface IDomainService<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
    }
}
