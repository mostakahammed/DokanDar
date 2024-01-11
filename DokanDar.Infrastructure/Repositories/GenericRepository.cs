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
            var entityEntry = await _dbSet.AddAsync(entity);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return true; 
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            var entityEntry = _dbSet.Remove(entity);
            return entityEntry.State == EntityState.Deleted;
        }
    }
}
