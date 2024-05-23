using Microsoft.EntityFrameworkCore;
using Core.Entities;
using System.Collections.Generic;
using System.Reflection;

namespace Infrastructure.Data
{
    /// <summary>
    /// Represents the database context for the application.
    /// </summary>
    public class StoreContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StoreContext"/> class.
        /// </summary>
        /// <param name="options">The DbContext options.</param>
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the DbSet for products.
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for product brands.
        /// </summary>
        public DbSet<ProductBrand> ProductBrands { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for product types.
        /// </summary>
        public DbSet<ProductType> ProductTypes { get; set; }

        /// <summary>
        /// Configures the model using configuration classes from the current assembly.
        /// </summary>
        /// <param name="modelBuilder">The model builder instance.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            if (Database.ProviderName == "Microsoft.EntityFrameworkCore.Sqlite")
            {
                foreach (var entityType in modelBuilder.Model.GetEntityTypes())
                {
                    var properties = entityType.ClrType.GetProperties().Where(p => p.PropertyType == typeof(decimal));

                    foreach (var property in properties)
                    {
                        modelBuilder.Entity(entityType.Name).Property(property.Name).HasConversion<double>();
                    }
                }
            }
        }
    }
}
