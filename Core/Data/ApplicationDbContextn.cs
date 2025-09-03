using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Link> Links { get; set; }
    }
}
