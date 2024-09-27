using BookManager.Data.Postgres.Abstractions;
using BookManager.Data.Postgres.Services;
using HotChocolate.Execution.Configuration;
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
    
    public static IServiceCollection AddBookManagerDataServices(this IServiceCollection services) =>
        services.AddScoped<IBookService, BookService>();
    
    public static IRequestExecutorBuilder AddBookManagerDataPostgres(this IRequestExecutorBuilder builder) =>
        builder.AddPostgresData();
}