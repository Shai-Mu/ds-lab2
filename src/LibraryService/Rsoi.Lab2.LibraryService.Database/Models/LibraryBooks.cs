namespace Rsoi.Lab2.LibraryService.Database.Models;

public class LibraryBooks
{
    public Guid Id { get; set; }
    
    public Guid LibraryId { get; set; }
    
    public Library? Library { get; set; }
    
    public Guid BooksId { get; set; }
    
    public Books? Books { get; set; }
    
    public int Count { get; set; }

    public LibraryBooks(Guid id, 
        Guid libraryId, 
        Guid booksId,
        int count)
    {
        Id = id;
        LibraryId = libraryId;
        BooksId = booksId;
        Count = count;
    }
}