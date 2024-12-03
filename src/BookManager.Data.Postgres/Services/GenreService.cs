using BookManager.Data.Postgres.Abstractions;
using BookManager.Data.Postgres.DataLoaders;
using BookManager.Domain;

namespace BookManager.Data.Postgres.Services;

internal class GenreService(BookManagerDbContext context, IGenreByIdDataLoader genreByIdDataLoader) : IGenreService
{
    public IQueryable<Genre> GetGenres()
        => context.Genres;

    public Task<Genre?> GetGenreByIdAsync(Guid id, CancellationToken cancellationToken)
        => genreByIdDataLoader.LoadAsync(id, cancellationToken);

    public Task<IEnumerable<Genre>> GetGenresByBookIdAsync(Guid bookId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}