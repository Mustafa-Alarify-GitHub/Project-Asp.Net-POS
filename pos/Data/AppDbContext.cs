using Microsoft.EntityFrameworkCore;
using pos.Models;

namespace pos.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Catogry> Catogries { get; set; }
        public DbSet<Custom> Customs { get; set; }
        public DbSet<Items> Items { get; set; }

    }
}
