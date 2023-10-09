using System.Runtime.Serialization;

namespace Rsoi.Lab2.ReservationService.HttpApi.Models;

[DataContract]
public class CreateReservationRequest
{
    [DataMember]
    public string Username { get; set; }
    
    [DataMember]
    public Guid BooksId { get; set; } 
    
    [DataMember]
    public Guid LibraryId { get; set; }
    
    [DataMember]
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