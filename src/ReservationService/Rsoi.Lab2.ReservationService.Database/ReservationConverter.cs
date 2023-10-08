using System.Diagnostics.CodeAnalysis;
using DbReservation = Rsoi.Lab2.ReservationService.Database.Reservation;
using CoreReservation = Rsoi.Lab2.ReservationService.Core.Reservation;

namespace Rsoi.Lab2.ReservationService.Database;

public static class ReservationConverter
{
    [return: NotNullIfNotNull("dbReservation")]
    public static CoreReservation? Convert(DbReservation? dbReservation)
    {
        if (dbReservation is null)
            return null;

        return new CoreReservation(dbReservation.Id,
            dbReservation.Username,
            dbReservation.BooksId,
            dbReservation.LibraryId,
            ReservationStatusConverter.Convert(dbReservation.ReservationStatus),
            dbReservation.StartDate,
            dbReservation.TillDate);
    }
}