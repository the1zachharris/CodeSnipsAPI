using CodeSnipsAPI.Entites;
using Microsoft.EntityFrameworkCore;

namespace CodeSnipsAPI.DbContexts
{
    public class UserInfoContext : DbContext
    {
        public DbSet<Snippet> Snippets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=SnippetInfo.db");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Snippet>()
                .HasData(
                    new Snippet("Python", "print('Hello, World!')")
                    {
                        Id = 1,
                    }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
