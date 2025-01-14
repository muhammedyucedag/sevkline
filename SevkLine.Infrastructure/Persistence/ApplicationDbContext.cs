using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SevkLine.Domain.Entities;
using SevkLine.Infrastructure.Configurations;

namespace SevkLine.Infrastructure.Persistence
{
    // Tasarım zamanında DbContext oluşturmak için kullanılan fabrika sınıfı
    internal class ApplicationDbContextDesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();

            // PostgreSQL bağlantı dizesi (SSL Mode eklenmiştir)
            builder.UseNpgsql("Host=localhost;Port=5432;Database=SevkLineDb;Username=sevkline;Password=e*HyQt9AY}Qs6Qw%;SSL Mode=Disable");
            return new ApplicationDbContext(builder.Options);
        }
    }

    // Ana DbContext sınıfı
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // DbSet tanımları
        public DbSet<Employee> Employees { get; set; }

        // OnModelCreating metodu (Fluent API yapılandırmaları burada uygulanır)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        }
    }
}