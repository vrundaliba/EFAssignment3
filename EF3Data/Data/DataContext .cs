
using EF3Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF3Data.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogType> BlogTypes { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostType> PostTypes { get; set; }
        public DbSet<User> Users { get; set; }

        public string DbPath { get; set; }
        public DataContext()
        {
            var path = AppContext.BaseDirectory;
            DbPath = Path.Join(path, "EFAssign3_Mathewd4.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }
    }
}