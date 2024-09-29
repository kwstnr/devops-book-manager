using BookManager.Data.Postgres.Abstractions;
using BookManager.Data.Postgres.Services;
using HotChocolate.Execution.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BookManager.Data.Postgres.Extensions;

public static class BookManagerDataServiceCollectionExtensions
{
    public static IServiceCollection AddBookManagerDataPostgres(this IServiceCollection services, string connectionString) =>
        services.AddDbContextPool<BookManagerDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });
    
    public static IServiceCollection AddBookManagerDataServices(this IServiceCollection services) =>
        services.AddScoped<IBookService, BookService>();
    
    public static IRequestExecutorBuilder AddBookManagerDataPostgres(this IRequestExecutorBuilder builder) =>
        builder.AddPostgresData();

    public static void MigrateDatabase<T>(IServiceProvider serviceProvider)
    {
        try
        {
            var context = serviceProvider.GetRequiredService<BookManagerDbContext>();
            context.Database.Migrate();
        }
        catch (Exception ex)
        {
            var logger = serviceProvider.GetRequiredService<ILogger<T>>();
            logger.LogError(ex, "An error occurred while applying migrations.");
        }
    }
}