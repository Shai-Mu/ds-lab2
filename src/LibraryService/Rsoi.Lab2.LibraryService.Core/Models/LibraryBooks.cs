namespace Rsoi.Lab2.LibraryService.Core.Models;

public class LibraryBooks
{
    public Guid Id { get; }
    
    public Guid LibraryId { get; }
    
    public Guid BooksId { get; }
    
    public int AvailableCount { get; }

    public LibraryBooks(Guid id,
        Guid libraryId, 
        Guid booksId, 
        int availableCount)
    {
        Id = id;
        LibraryId = libraryId;
        BooksId = booksId;
        AvailableCount = availableCount;
    }
}