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
        public DokanDbContext(DbContextOptions<DokanDbContext> options) : base(options) { }

        public DbSet<Category> Category { get; set; }
        public DbSet<Shelf> Shelf { get; set; }
    }
}
