using BookManager.Data.Postgres.Extensions;
using BookManager.Graph.Extensions;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                       ?? Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING")
                       ?? throw new InvalidOperationException("Connection string is missing");

builder.Services.AddBookManagerDataPostgres(connectionString);

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
