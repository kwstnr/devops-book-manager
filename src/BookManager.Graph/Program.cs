using BookManager.Data.Postgres;
using BookManager.Data.Postgres.Extensions;
using BookManager.Graph.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddBookManagerDataPostgres(builder.Configuration.GetConnectionString("DefaultConnection") ??
                                            throw new InvalidOperationException());

builder.Services
    .AddBookManagerDataServices()
    .AddGraphQLServer()
    .AddTypes()
    .AddBookManagerGraphConventions()
    .AddBookManagerDataPostgres();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<DbContext>();
        context.Database.Migrate();
    }
    catch (Exception ex)
    {
        // Log errors or handle them as necessary
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while applying migrations.");
    }
}

app.MapGraphQL();

app.RunWithGraphQLCommands(args);
