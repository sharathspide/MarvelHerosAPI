using MarvelHerosAPI.DataModel;
using Microsoft.EntityFrameworkCore;

namespace MarvelHerosAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions<DataContext> options): base(options)
        {

        }

        public DbSet<Hero> Heros { get; set; }
    }
}
