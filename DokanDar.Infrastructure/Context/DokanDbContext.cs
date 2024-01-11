using DokanDar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokanDar.Infrastructure.Context
{
    public class DokanDbContext : DbContext
    {
        public DokanDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Category> Category { get; set; }
    }
}
