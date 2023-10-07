using Rsoi.Lab2.LibraryService.Core.Models.Enums;

namespace Rsoi.Lab2.LibraryService.Core.Models;

public class Books
{
    public Guid Id { get;}
    
    public string Name { get; }
    
    public string Author { get; }
    
    public string Genre { get;  }
    
    public BookCondition Condition { get; }

    public Books(Guid id, 
        string name, 
        string author, 
        string genre, 
        BookCondition condition)
    {
        Id = id;
        Name = name;
        Author = author;
        Genre = genre;
        Condition = condition;
    }
}