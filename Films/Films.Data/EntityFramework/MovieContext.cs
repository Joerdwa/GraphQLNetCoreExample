using Microsoft.EntityFrameworkCore;
using Films.Core.Models;

namespace Films.Data.EntityFramework
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions options): base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Film> Films { get; set; }
    }
}
