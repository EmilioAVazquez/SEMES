using System;
using Microsoft.EntityFrameworkCore;
using SEMES.Models;

namespace SEMES
{
    class SemesDbContext : DbContext {
        public SemesDbContext(DbContextOptions options)
        : base(options) {}
        public DbSet<Wearhouse> Wearhouse { get; set; } 
        public DbSet<Transaction> Transaction { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<Admi> Admi { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Client> Client { get; set; }
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