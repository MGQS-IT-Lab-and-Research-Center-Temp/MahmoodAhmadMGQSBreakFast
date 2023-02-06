using Microsoft.EntityFrameworkCore;
using BreakFast.Entity;

namespace BreakFast.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Breakfast> Breakfasts { get; set; }
    }
}
 