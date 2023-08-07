using MoviesAPI.Models.Database;
using System.Data.Entity;

namespace MoviesAPI.Database
{
#nullable disable
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base()
        {}

        public DbSet<Movie> Movies { get; set; }
        public DbSet<SearchHistory> SearchHistories { get; set; }
    }
}
