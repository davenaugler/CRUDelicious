using Microsoft.EntityFrameworkCore;

namespace CRUDelicious.Models
{
    public class CRUDeliciusContext : DbContext
    {
        public CRUDeliciusContext(DbContextOptions options) : base(options) {}
        public DbSet<Dish> Dishes {get; set;}
    }
}