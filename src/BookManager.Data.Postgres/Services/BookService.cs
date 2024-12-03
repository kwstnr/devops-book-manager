using BookManager.Data.Postgres.Abstractions;
using BookManager.Data.Postgres.DataLoaders;
using BookManager.Domain;

namespace BookManager.Data.Postgres.Services;

internal class BookService(BookManagerDbContext context, IBookByIdDataLoader bookByIdDataLoader, IBooksByAuthorIdDataLoader booksByAuthorIdDataLoader) : IBookService
{
    public IQueryable<Book> GetBooks() => context.Books;

    public Task<Book?> GetBookByIdAsync(Guid id, CancellationToken cancellationToken) =>
        bookByIdDataLoader.LoadAsync(id, cancellationToken);

    public async Task<IEnumerable<Book>> GetBooksByAuthorIdAsync(Guid authorId, CancellationToken cancellationToken)
        => await booksByAuthorIdDataLoader.LoadAsync(authorId, cancellationToken) ?? new List<Book>();

    public Task<IEnumerable<Book>> GetBooksByGenreIdAsync(Guid genreId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}