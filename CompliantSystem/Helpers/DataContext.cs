using Microsoft.EntityFrameworkCore;
using CompliantSystem.Models;

namespace CompliantSystem.Helpers
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Complaint> Complaints { get; set; }
    }
}