using BookManager.Domain;

namespace BookManager.Graph.Nodes;

[ObjectType<Book>]
public static partial class BookNode
{
    static partial void Configure(IObjectTypeDescriptor<Book> descriptor)
    {
        descriptor.Ignore(x => x.AuthorId);
    }
}