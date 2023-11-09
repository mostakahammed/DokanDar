using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokanDar.Application.Services.GenericServices
{
    public interface IGenericService<T, TEntityDTO> 
        where T : class
        where TEntityDTO : class
    {
        Task<TEntityDTO> GetAsync(int id);
        Task<IEnumerable<TEntityDTO>> GetAllAsync();
        Task<bool> AddAsync(TEntityDTO entity);
        Task<bool> UpdateAsync(int id, TEntityDTO entity);
        Task<bool> DeleteAsync(TEntityDTO entity);
    }
}
