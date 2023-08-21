using Microsoft.EntityFrameworkCore;
using Test.Models;

namespace Test.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
               
        }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Film", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Snack", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Popcorn", DisplayOrder = 3 },
                new Category { Id = 4, Name = "Book", DisplayOrder = 4}
            );
        }
    }
}
