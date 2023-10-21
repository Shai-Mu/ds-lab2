namespace Rsoi.Lab2.ReservationService.Core;

public class Reservation
{
    public Guid Id { get; set; }
    
    public string Username { get; set; }
    
    public Guid BooksId { get; set; }
    
    public Guid LibraryId { get; set; }
    
    public ReservationStatus ReservationStatus { get; set; }
    
    public DateOnly StartDate { get; set; }
    
    public DateOnly TillDate { get; set; }

    public Reservation(Guid id,
        string username,
        Guid booksId,
        Guid libraryId,
        ReservationStatus reservationStatus,
        DateOnly startDate,
        DateOnly tillDate)
    {
        Id = id;
        Username = username;
        BooksId = booksId;
        LibraryId = libraryId;
        ReservationStatus = reservationStatus;
        StartDate = startDate;
        TillDate = tillDate;
    }
}