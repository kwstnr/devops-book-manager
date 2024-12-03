using BookManager.Domain;

namespace BookManager.Data.Postgres.Abstractions;

public interface IGenreService
{
    IQueryable<Genre> GetGenres();
    Task<Genre?> GetGenreByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<Genre>> GetGenresByBookIdAsync(Guid bookId, CancellationToken cancellationToken);
}