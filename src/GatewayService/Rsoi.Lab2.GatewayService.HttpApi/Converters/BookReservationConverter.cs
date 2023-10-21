using Rsoi.Lab2.GatewayService.HttpApi.Models;
using Rsoi.Lab2.LibraryService.Dto.Models;
using Rsoi.Lab2.ReservationService.Core;

namespace Rsoi.Lab2.GatewayService.HttpApi.Converters;

public static class BookReservationConverter
{
    public static BookReservationResponse Convert(Reservation reservation, Books books, Library library)
    {
        return new BookReservationResponse(reservation.Id,
            ReservationStatusConverter.Convert(reservation.ReservationStatus),
            reservation.StartDate.ToString("yyyy-MM-dd"),
            reservation.TillDate.ToString("yyyy-MM-dd"),
            LibraryBookConverter.Convert(books),
            LibraryConverter.Convert(library));
    }
}