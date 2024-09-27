using BookManager.Data.Postgres.Configurations;
using BookManager.Domain;
using Microsoft.EntityFrameworkCore;

namespace BookManager.Data.Postgres;

internal class BookManagerDbContext(DbContextOptions<BookManagerDbContext> options) : DbContext(options)
{
    internal DbSet<Book> Books { get; set; }
    
    internal DbSet<Author> Authors { get; set; }
    
    internal DbSet<Genre> Genres { get; set; }
    
    internal DbSet<BookGenreAssignment> BookGenreAssignments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new AuthorConfiguration());
        modelBuilder.ApplyConfiguration(new BookConfiguration());
        modelBuilder.ApplyConfiguration(new GenreConfiguration());
        modelBuilder.ApplyConfiguration(new BookGenreAssignmentConfiguration());
    }
}