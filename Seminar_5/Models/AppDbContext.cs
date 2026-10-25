using Microsoft.EntityFrameworkCore;

namespace Seminar_5.Models
{
    internal class AppDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(
                AppContext.BaseDirectory,
                "app.db"
            );

            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }
    }
}
