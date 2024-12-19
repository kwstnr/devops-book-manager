using HotChocolate.Execution.Configuration;

namespace BookManager.Graph.Extensions;

internal static class GraphQLExtensions
{
    internal static IRequestExecutorBuilder AddBookManagerGraphConventions(this IRequestExecutorBuilder builder) =>
        builder
            .AddFiltering()
            .AddSorting()
            .AddProjections()
            .AddDefaultNodeIdSerializer(useUrlSafeBase64: true)
            .AddGlobalObjectIdentification();
}