using BookManager.Data.Postgres.Extensions;
using BookManager.Graph.Extensions;

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
    BookManagerDataServiceCollectionExtensions.MigrateDatabase<Program>(scope.ServiceProvider);
}

app.MapGraphQL();

app.RunWithGraphQLCommands(args);
