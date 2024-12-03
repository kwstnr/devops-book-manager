using BookManager.Domain;
using GreenDonut;
using Microsoft.EntityFrameworkCore;

namespace BookManager.Data.Postgres.DataLoaders;

internal static class GenreDataLoaders
{
    [DataLoader]
    internal static async Task<IReadOnlyDictionary<Guid, Genre>> GetGenreByIdAsync(
        IReadOnlyList<Guid> genreIds,
        BookManagerDbContext context,
        CancellationToken cancellationToken)
        => await context.Genres
            .Where(a => genreIds.Contains(a.Id))
            .ToDictionaryAsync(a => a.Id, cancellationToken);

    [DataLoader]
    internal static async Task<IReadOnlyDictionary<Guid, IEnumerable<Genre>>> GetGenresByBookIdAsync(
        IReadOnlyList<Guid> bookIds,
        BookManagerDbContext context,
        CancellationToken cancellationToken)
        => await context.Books
            .Where(b => bookIds.Contains(b.Id))
            .Select(b => new { Key = b.Id, Genres = b.Genres.ToList() })
            .ToDictionaryAsync(g => g.Key, g => g.Genres.AsEnumerable(), cancellationToken);
}