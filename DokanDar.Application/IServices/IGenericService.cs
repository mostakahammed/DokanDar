

namespace DokanDar.Application.IServices
{
    public interface IGenericService<T, TDto> 
        where T : class 
        where TDto : class
    {
        Task<TDto> GetByIdAsync(int id);
        Task<IEnumerable<TDto>> GetAllAsync();
        Task<bool> AddAsync(TDto entity);
        Task<bool> UpdateAsync(TDto entity);
        Task<bool> DeleteAsync(int id);
    }
}
