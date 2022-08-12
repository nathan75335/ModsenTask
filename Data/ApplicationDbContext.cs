using Microsoft.EntityFrameworkCore;
using TaskModsen.Entities;

namespace TaskModsen.Data
{
    /// <summary>
    /// CLass db context that will later implement the data from the database
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<EventFeast> EventFeasts { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
