using System.Runtime.Serialization;
using Rsoi.Lab2.ReservationService.Core;

namespace Rsoi.Lab2.ReservationService.HttpApi.Models;

[DataContract]
public class CloseReservationResponse
{
    public DateTimeOffset CloseDate { get; set; }
    
    public Reservation Reservation { get; set; }

    public CloseReservationResponse(Reservation reservation, DateTimeOffset closeDate)
    {
        Reservation = reservation;
        CloseDate = closeDate;
    }
}