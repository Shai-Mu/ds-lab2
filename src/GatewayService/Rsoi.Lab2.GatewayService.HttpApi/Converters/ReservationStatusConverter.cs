using Rsoi.Lab2.GatewayService.HttpApi.Models.Enum;
using Rsoi.Lab2.ReservationService.Core;
using static System.String;

namespace Rsoi.Lab2.GatewayService.HttpApi.Converters;

public static class ReservationStatusConverter
{
    public static Status Convert(ReservationStatus status)
    {
        return status switch
        {
            ReservationStatus.Expired => Status.Expired,
            ReservationStatus.Rented => Status.Rented,
            ReservationStatus.Returned => Status.Returned,
            _ => throw new ArgumentOutOfRangeException(nameof(status), status, Empty)
        };
    }
    
    public static ReservationStatus Convert(Status status)
    {
        return status switch
        {
            Status.Expired => ReservationStatus.Expired,
            Status.Rented => ReservationStatus.Rented,
            Status.Returned => ReservationStatus.Returned,
            _ => throw new ArgumentOutOfRangeException(nameof(status), status, Empty)
        };
    }
}