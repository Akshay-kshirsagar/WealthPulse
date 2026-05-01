using BillingService.Models;
using Microsoft.EntityFrameworkCore;

namespace BillingService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<FeePlan> FeePlans => Set<FeePlan>();
        public DbSet<Invoice> Invoices => Set<Invoice>();
    }
}
