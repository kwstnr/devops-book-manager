using BookManager.Data.Postgres.Configurations;
using BookManager.Data.Postgres.Seeding;
using BookManager.Domain;
using Microsoft.EntityFrameworkCore;

namespace BookManager.Data.Postgres;

internal class BookManagerDbContext(DbContextOptions<BookManagerDbContext> options) : DbContext(options)
{
    
    internal DbSet<Author> Authors { get; set; }
    internal DbSet<Book> Books { get; set; }
    
    internal DbSet<Genre> Genres { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new AuthorConfiguration());
        modelBuilder.ApplyConfiguration(new BookConfiguration());
        modelBuilder.ApplyConfiguration(new GenreConfiguration());

        modelBuilder.Entity("BookGenre").HasData(SeedingData.BookGenreAssignments);
    }
}