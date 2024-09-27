namespace BookManager.Domain;

public class Genre
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public IEnumerable<BookGenreAssignment> BookGenreAssignments { get; set; }
}