using BookManager.Data.Postgres.Abstractions;
using BookManager.Domain;

namespace BookManager.Data.Postgres.Services;

internal class BookService(BookManagerDbContext context) : IBookService
{
    public IQueryable<Book> GetBooks() => context.Books;

    public Task<Book?> GetBookByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Book>> GetBooksByAuthorIdAsync(Guid authorId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Book>> GetBooksByGenreIdAsync(Guid genreId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}