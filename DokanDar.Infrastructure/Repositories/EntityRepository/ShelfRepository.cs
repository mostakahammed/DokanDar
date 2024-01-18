using DokanDar.Domain.Entities;
using DokanDar.Domain.IRepositories.EntityRepository;
using DokanDar.Infrastructure.Context;


namespace DokanDar.Infrastructure.Repositories.EntityRepository
{
    public class ShelfRepository : GenericRepository<Shelf>, IShelfRepository
    {
        public ShelfRepository(DokanDbContext context) : base(context)
        {
        }
    }
}
