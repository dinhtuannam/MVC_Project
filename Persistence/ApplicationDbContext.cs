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
    }
}