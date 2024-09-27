using BookManager.Domain;
using Microsoft.EntityFrameworkCore;

namespace BookManager.Data.Postgres;

internal class BookManagerDbContext : DbContext
{
    internal DbSet<Book> Books { get; set; }
    
    internal DbSet<Author> Authors { get; set; }
    
    internal DbSet<Genre> Genres { get; set; }
}