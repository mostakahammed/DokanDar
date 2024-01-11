using DokanDar.Domain.Entities;
using DokanDar.Domain.IRepositories.EntityRepository;
using DokanDar.Infrastructure.Context;


namespace DokanDar.Infrastructure.Repositories.EntityRepository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DokanDbContext context) : base(context)
        {
        }
    }
}
