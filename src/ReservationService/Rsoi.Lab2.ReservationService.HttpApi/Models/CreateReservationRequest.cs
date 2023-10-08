using System.Runtime.Serialization;

namespace Rsoi.Lab2.ReservationService.HttpApi.Models;

[DataContract]
public class CreateReservationRequest
{
    public string Username { get; set; }
    
    public Guid BooksId { get; set; } 
    
    public Guid LibraryId { get; set; }
    
    public DateTimeOffset TillDate { get; set; }

    public CreateReservationRequest(string username, 
        Guid booksId, 
        Guid libraryId, 
        DateTimeOffset tillDate)
    {
        Username = username;
        BooksId = booksId;
        LibraryId = libraryId;
        TillDate = tillDate;
    }
}