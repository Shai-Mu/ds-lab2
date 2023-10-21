using System.Runtime.Serialization;

namespace Rsoi.Lab2.ReservationService.Dto.Models;

[DataContract]
public class GetReservationRequest
{
    public string Username { get; set; }
    
    public Guid LibraryId { get; set; }
    
    public Guid BooksId { get; set; }
}