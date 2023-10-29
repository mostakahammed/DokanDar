using DokanDar.Domain;
using DokanDar.Domain.Entities;
using DokanDar.Domain.Interfaces.EntityRepository;
using DokanDar.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokanDar.Infrastructure.Implementations.EntityRepository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DokanDbContext context) : base(context)
        {
        }
    }
}
