using BookManager.Data.Postgres.Abstractions;
using BookManager.Data.Postgres.DataLoaders;
using BookManager.Domain;

namespace BookManager.Data.Postgres.Services;

internal class AuthorService(BookManagerDbContext context, IAuthorByIdDataLoader authorByIdDataLoader) : IAuthorService
{
    public IQueryable<Author> GetAuthors() => context.Authors;

    public Task<Author?> GetAuthorByIdAsync(Guid id, CancellationToken cancellationToken) =>
        authorByIdDataLoader.LoadAsync(id, cancellationToken);

    public Task<Author> GetAuthorByBookIdAsync(Guid bookId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}