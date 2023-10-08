using Microsoft.EntityFrameworkCore;
using Rsoi.Lab2.ReservationService.Core;

namespace Rsoi.Lab2.ReservationService.Database;

public class ReservationRepository : IReservationRepository
{
    private readonly ReservationContext _reservationContext;

    public ReservationRepository(ReservationContext reservationContext)
    {
        _reservationContext = reservationContext;
    }

    public async Task<Guid> CreateReservationAsync(string username, Guid booksId, Guid libraryId, DateTimeOffset tillDate)
    {
        var reservation = new Reservation(Guid.NewGuid(), username, booksId, libraryId, ReservationStatus.Rented,
            DateTimeOffset.Now, tillDate);

        _reservationContext.Reservations.Add(reservation);

        await _reservationContext.SaveChangesAsync();

        return reservation.Id;
    }

    public async Task<List<Core.Reservation>> GetReservationsForUserAsync(string username)
    {
        var reservations = await _reservationContext.Reservations
            .Where(r => r.Username == username)
            .AsNoTracking()
            .ToListAsync();

        return reservations
            .Select(ReservationConverter.Convert)
            .ToList()!;
    }

    public async Task<Core.Reservation> GetReservationForUserBookAndLibraryAsync(string username, Guid booksId, Guid libraryId)
    {
        var reservation = await _reservationContext.Reservations
            .OrderByDescending(r => r.StartDate)
            .AsNoTracking()
            .FirstAsync(r => r.Username == username 
                             && r.BooksId == booksId 
                             && r.LibraryId == libraryId);

        return ReservationConverter.Convert(reservation);
    }

    public async Task UpdateReservationAsync(Guid id, Core.ReservationStatus status)
    {
        var reservation = await _reservationContext.Reservations
            .FirstAsync(r => r.Id == id);

        reservation.ReservationStatus = ReservationStatusConverter.Convert(status);

        await _reservationContext.SaveChangesAsync();
    }

    public async Task<Core.Reservation?> FindReservationAsync(Guid id)
    {
        var reservation = await _reservationContext.Reservations
            .FirstOrDefaultAsync(r => r.Id == id);

        return ReservationConverter.Convert(reservation);
    }
}