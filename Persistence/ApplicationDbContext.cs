using Microsoft.EntityFrameworkCore;
using Entity;
namespace Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<Role> Roles { get; set; }  
        public DbSet<Product> Products {  get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Discount> Discounts { get; set; }
		public DbSet<Banner> Banners { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<DetailOrder> DetailOrders { get; set; }
	}
}