using DokanDar.Domain.IRepositories;
using DokanDar.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;


namespace DokanDar.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DokanDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(DokanDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<T>();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<bool> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            var successresult = await _context.SaveChangesAsync();
            return successresult > 0 ? true : false;
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            var successresult = await _context.SaveChangesAsync();
            return successresult > 0 ? true : false;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            var successresult = await _context.SaveChangesAsync();
            return successresult > 0 ? true : false;
        }
    }
}
