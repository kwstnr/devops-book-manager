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
}