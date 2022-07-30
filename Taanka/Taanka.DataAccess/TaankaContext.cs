using Microsoft.EntityFrameworkCore;
using Taanka.Models.DomainModels;

namespace Taanka.DataAccess
{
    public class TaankaContext:DbContext
    {
        public DbSet<Role> Roles{ get; set; }
        public DbSet<User> Users{ get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders{ get; set; }
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Data Source=HUSSAIN\\HACK3R;Initial Catalog=FashionProjectDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}