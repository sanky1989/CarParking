using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parking.Core.Abstractions
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> SelectAllAsync();
    }
}
