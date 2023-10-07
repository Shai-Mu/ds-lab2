using Rsoi.Lab2.LibraryService.Database.Models.Enums;

namespace Rsoi.Lab2.LibraryService.Database.Models;

public class Books
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public string Author { get; set; }
    
    public string Genre { get; set; }
    
    public BookCondition Condition { get; set; }
    
    
    public ICollection<LibraryBooks>? LibrariesBooks { get; set; }

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