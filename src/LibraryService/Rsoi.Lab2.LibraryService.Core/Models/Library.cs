namespace Rsoi.Lab2.LibraryService.Core.Models;

public class Library
{
    public Guid Id { get; }
    
    public string Name { get; }
    
    public string City { get; }
    
    public string Address { get; }

    public Library(Guid id, 
        string name, 
        string city, 
        string address)
    {
        Id = id;
        Name = name;
        City = city;
        Address = address;
    }
}