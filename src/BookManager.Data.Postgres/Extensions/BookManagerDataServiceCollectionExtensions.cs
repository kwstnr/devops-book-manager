using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookManager.Data.Postgres.Extensions;

public static class BookManagerDataServiceCollectionExtensions
{
    public static IServiceCollection AddBookManagerDataPostgres(this IServiceCollection services, string connectionString) =>
        services.AddDbContextPool<BookManagerDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });
}