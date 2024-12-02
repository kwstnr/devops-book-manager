using BookManager.Domain;
using GreenDonut;
using Microsoft.EntityFrameworkCore;

namespace BookManager.Data.Postgres.DataLoaders;

internal static class AuthorDataLoaders
{
    [DataLoader]
    internal static async Task<IReadOnlyDictionary<Guid, Author>> GetAuthorByIdAsync(
        IReadOnlyList<Guid> keys,
        BookManagerDbContext context,
        CancellationToken cancellationToken)
        => await context.Authors
            .Where(a => keys.Contains(a.Id))
            .ToDictionaryAsync(a => a.Id, cancellationToken);
}