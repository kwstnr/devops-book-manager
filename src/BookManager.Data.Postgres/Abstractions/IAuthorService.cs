using BookManager.Domain;

namespace BookManager.Data.Postgres.Abstractions;

public interface IAuthorService
{
    IQueryable<Author> GetAuthors();
    Task<Author?> GetAuthorByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<Author> GetAuthorByBookIdAsync(Guid bookId, CancellationToken cancellationToken);
}