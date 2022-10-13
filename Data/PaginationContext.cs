using Microsoft.EntityFrameworkCore;
using Models;

namespace Data
{
    public class PaginationContext : DbContext
    {
        public PaginationContext(DbContextOptions<PaginationContext> options) : base(options)
        {
                
        }

        //This is just to create the table and instert data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>().HasData
                (
                new Book { Id = 1, Name = "The Hitchhiker's Guide to the Galaxy" },
                new Book { Id = 2, Name = "Ready Player One" },
                new Book { Id = 3, Name = "1984" },
                new Book { Id = 4, Name = "The Matrix Resurrections" },
                new Book { Id = 5, Name = "Diablo 2: Resurrected" },
                new Book { Id = 6, Name = "Super Nintendo Entertainment System" },
                new Book { Id = 7, Name = "Day of the Tentacle" },
                new Book { Id = 8, Name = "Back to the Future" },
                new Book { Id = 9, Name = "Toy Story" },
                new Book { Id = 10, Name = "Brave New World" }
                );
        }
        //? is just to not see the nullable warning
        public DbSet<Book>? Books { get; set; }
    }
}