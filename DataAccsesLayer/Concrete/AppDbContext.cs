using Microsoft.EntityFrameworkCore;
using Entity.Concrete; // Entity sınıf kütüphanenizi referans olarak ekleyin

namespace DataAccsess.Concrete
{
    public class AppDbContext : DbContext
    {
        /*public AppDbContext()
        {
        }*/

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost; Database=postgres; Username=postgres; Password=Ali50512506");
            }
        }

        public DbSet<Customer> customers { get; set; }
        public DbSet<CustomerAddress> addresses { get; set; }
        public DbSet<CustomerCom> customerComs { get; set; }
    }
}
