using System;
using Microsoft.EntityFrameworkCore;

namespace SEMES
{
    class SemesDbContext : DbContext {
        public SemesDbContext(DbContextOptions options)
        : base(options) {}
        public DbSet<Product> Product { get; set; }
        // DbSet<T> type properties for other domain models
    }

    class SemesDbContextFactory {
        public static SemesDbContext Create() {
            var optionsBuilder = new DbContextOptionsBuilder<SemesDbContext>();
            optionsBuilder.UseNpgsql("Host=34.70.240.234;Database=Stella;Username=postgres;Password=chavita");
            var dbContext = new SemesDbContext(optionsBuilder.Options);
            return dbContext;
        }
     }
    
}