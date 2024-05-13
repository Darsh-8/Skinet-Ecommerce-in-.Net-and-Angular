using Microsoft.EntityFrameworkCore;
using Core.Entities;
using System.Collections.Generic;

namespace Infrastructure.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
