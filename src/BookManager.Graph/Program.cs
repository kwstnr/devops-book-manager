using BookManager.Data.Postgres.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddBookManagerDataPostgres(builder.Configuration.GetConnectionString("DefaultConnection") ??
                                            throw new InvalidOperationException());

builder.Services
    .AddGraphQLServer()
    .AddTypes();

var app = builder.Build();

app.MapGraphQL();

app.RunWithGraphQLCommands(args);
