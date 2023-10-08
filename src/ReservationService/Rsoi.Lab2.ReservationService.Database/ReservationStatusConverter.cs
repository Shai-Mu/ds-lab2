using DbReservationStatus = Rsoi.Lab2.ReservationService.Database.ReservationStatus;
using CoreReservationStatus = Rsoi.Lab2.ReservationService.Core.ReservationStatus;

namespace Rsoi.Lab2.ReservationService.Database;

public static class ReservationStatusConverter
{
    public static CoreReservationStatus Convert(DbReservationStatus dbReservationStatus)
    {
        return dbReservationStatus switch
        {
            DbReservationStatus.Expired => CoreReservationStatus.Expired,
            DbReservationStatus.Rented => CoreReservationStatus.Rented,
            DbReservationStatus.Returned => CoreReservationStatus.Returned,
            _ => throw new ArgumentOutOfRangeException(nameof(dbReservationStatus), dbReservationStatus, null)
        };
    }
    
    public static DbReservationStatus Convert(CoreReservationStatus coreReservationStatus)
    {
        return coreReservationStatus switch
        {
            CoreReservationStatus.Expired => DbReservationStatus.Expired,
            CoreReservationStatus.Rented => DbReservationStatus.Rented,
            CoreReservationStatus.Returned => DbReservationStatus.Returned,
            _ => throw new ArgumentOutOfRangeException(nameof(coreReservationStatus), coreReservationStatus, null)
        };
    }
}