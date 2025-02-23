using Microsoft.EntityFrameworkCore;
using Tech.Data.domain.Entities;

namespace Tech.Data
{
    public class TechLibraryContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source= C:\\Users\\Duck\\source\\repos\\TechLibrary\\TechLibrary.Api\\db\\TechLibraryDb.db");
        }
    }
}
