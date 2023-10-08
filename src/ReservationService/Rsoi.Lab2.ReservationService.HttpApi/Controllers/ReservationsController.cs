using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Rsoi.Lab2.ReservationService.Core;
using Rsoi.Lab2.ReservationService.HttpApi.Models;

namespace Rsoi.Lab2.ReservationService.HttpApi.Controllers;

public class ReservationsController : ControllerBase
{
    private readonly IReservationRepository _reservationRepository;

    public ReservationsController(IReservationRepository reservationRepository)
    {
        _reservationRepository = reservationRepository;
    }

    [HttpPost]
    [Route("reservations")]
    public async Task<IActionResult> CreateReservationAsync([FromBody]CreateReservationRequest createReservationRequest)
    {
        var reservationId = await _reservationRepository.CreateReservationAsync(
            createReservationRequest.Username,
            createReservationRequest.BooksId, 
            createReservationRequest.LibraryId, 
            createReservationRequest.TillDate);

        return Ok(reservationId);
    }

    [HttpGet]
    [Route("user/{username}/reservations")]
    public async Task<IActionResult> GetReservationsForUserAsync([FromQuery][Required] string username)
    {
        var reservations = await _reservationRepository.GetReservationsForUserAsync(username);

        return Ok(reservations);
    }

    [HttpGet]
    [Route("reservations")]
    public async Task<IActionResult> GetReservationAsync(
        [FromBody][Required] GetReservationRequest getReservationRequest)
    {
        var reservation = await _reservationRepository.GetReservationForUserBookAndLibraryAsync(
            getReservationRequest.Username,
            getReservationRequest.BooksId,
            getReservationRequest.LibraryId);

        return Ok(reservation);
    }

    [HttpPatch]
    [Route("reservations/{id}")]
    public async Task<IActionResult> CloseReservationAsync([FromRoute]Guid id)
    {
        var reservation = await _reservationRepository.FindReservationAsync(id);

        if (reservation is null)
            return NotFound();

        var status = reservation.TillDate.Date > DateTimeOffset.Now.Date 
            ? ReservationStatus.Returned 
            : ReservationStatus.Expired;

        await _reservationRepository.UpdateReservationAsync(id, status);

        return Ok(new CloseReservationResponse(status, DateTimeOffset.Now.Date));
    }
}