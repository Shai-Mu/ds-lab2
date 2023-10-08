namespace Rsoi.Lab2.ReservationService.Core;

public interface IReservationRepository
{
    public Task<Guid> CreateReservationAsync(string username, Guid booksId, Guid libraryId, DateTimeOffset tillDate);

    public Task<List<Reservation>> GetReservationsForUserAsync(string username);

    public Task<Reservation> GetReservationForUserBookAndLibraryAsync(string username, Guid booksId, Guid libraryId);

    public Task UpdateReservationAsync(Guid id, ReservationStatus status);

    public Task<Reservation?> FindReservationAsync(Guid id);
}