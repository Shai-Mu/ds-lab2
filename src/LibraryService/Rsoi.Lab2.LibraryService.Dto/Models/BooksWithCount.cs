using Rsoi.Lab2.LibraryService.Core.Models;
using Rsoi.Lab2.LibraryService.Core.Models.Enums;

namespace Rsoi.Lab2.LibraryService.Dto.Models;

public class BooksWithCount
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public string Author { get; set; }
    
    public string Genre { get; set; }
    
    public BookCondition Condition { get; set; }
    
    public int Count { get; set; }
    
    public BooksWithCount(Guid id, 
        string name, 
        string author, 
        string genre, 
        BookCondition condition,
        int count)
    {
        Id = id;
        Name = name;
        Author = author;
        Genre = genre;
        Condition = condition;
        Count = count;
    }
}