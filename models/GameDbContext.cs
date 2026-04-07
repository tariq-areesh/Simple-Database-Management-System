using Microsoft.EntityFrameworkCore;
using gameDb.Models;

namespace gameDb.Data
{
    public class GameDbContext : DbContext
    {
        public GameDbContext(DbContextOptions<GameDbContext> options) : base(options) { }

        public DbSet<Game> Games { get; set; }
    }
}
