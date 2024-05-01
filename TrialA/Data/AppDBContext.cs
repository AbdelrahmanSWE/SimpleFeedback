using Microsoft.EntityFrameworkCore;

namespace TrialA.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options)
        : base(options)
        {

        }
        public DbSet<Models.Message> Messages { get; set; }
    }
    
}
