using System.Runtime.Serialization;

namespace Rsoi.Lab2.ReservationService.Dto.Models;

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
    public DateOnly TillDate { get; set; }

    public CreateReservationRequest(string username, 
        Guid booksId, 
        Guid libraryId, 
        DateOnly tillDate)
    {
        Username = username;
        BooksId = booksId;
        LibraryId = libraryId;
        TillDate = tillDate;
    }
}