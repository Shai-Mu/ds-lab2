using System.Runtime.Serialization;
using Rsoi.Lab2.ReservationService.Core;

namespace Rsoi.Lab2.ReservationService.HttpApi.Models;

[DataContract]
public class CloseReservationResponse
{
    public ReservationStatus Status { get; set; }
    
    public DateTimeOffset CloseDate { get; set; }

    public CloseReservationResponse(ReservationStatus status, DateTimeOffset closeDate)
    {
        Status = status;
        CloseDate = closeDate;
    }
}