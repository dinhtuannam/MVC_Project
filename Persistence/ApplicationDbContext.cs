using Microsoft.EntityFrameworkCore;
using Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Persistence
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products {  get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Discount> Discounts { get; set; }
		public DbSet<Banner> Banners { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<DetailOrder> DetailOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<DetailOrder>().HasKey(x => new { x.OrderId, x.ProductId });
    
            builder.Entity<IdentityUserRole<string>>().HasKey(x => new { x.UserId, x.RoleId });

            builder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Id = "2ca8fa08-4a80-4714-a5fb-17b7316fddc4",
                Name = "Admin",
                NormalizedName = "ADMIN".ToUpper()
            },
            new IdentityRole
            {
                Id = "88ac3925-8432-4f60-89e2-96433d08bbcf",
                Name = "Manager",
                NormalizedName = "MANAGER".ToUpper()
            }
            );
            var hasher = new PasswordHasher<IdentityUser>();

            builder.Entity<IdentityUser>().HasData(
               new IdentityUser
               {
                   Id = "ff045d07-be86-4a4e-bfa4-0264ec832c12",
                   UserName = "Super Admin",
                   NormalizedUserName = "SUPER ADMIN".ToUpper(),
                   Email = "admin@gmail.com",
                   NormalizedEmail = "ADMIN@GMAIL.COM".ToUpper(),
                   PasswordHash = hasher.HashPassword(null, "Admin@123")
               }
            );

            builder.Entity<IdentityUserRole<string>>().HasData(

                new IdentityUserRole<string>
                {
                    UserId = "ff045d07-be86-4a4e-bfa4-0264ec832c12",
                    RoleId = "2ca8fa08-4a80-4714-a5fb-17b7316fddc4"
                },
                new IdentityUserRole<string>
                {
                    UserId = "ff045d07-be86-4a4e-bfa4-0264ec832c12",
                    RoleId = "88ac3925-8432-4f60-89e2-96433d08bbcf"
                }
            );
        }

    }
}