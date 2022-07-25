using Microsoft.EntityFrameworkCore;
using PoemAPI.Models;

namespace PoemAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Poem>? Poems { get; set; }
    }
}