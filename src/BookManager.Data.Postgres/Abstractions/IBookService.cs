using BookManager.Domain;

namespace BookManager.Data.Postgres.Abstractions;

public interface IBookService
{
    IQueryable<Book> GetBooks();
    
    Task<Book?> GetBookByIdAsync(Guid id, CancellationToken cancellationToken);
    
    Task<IEnumerable<Book>> GetBooksByAuthorIdAsync(Guid authorId, CancellationToken cancellationToken);
    
    Task<IEnumerable<Book>> GetBooksByGenreIdAsync(Guid genreId, CancellationToken cancellationToken);
}