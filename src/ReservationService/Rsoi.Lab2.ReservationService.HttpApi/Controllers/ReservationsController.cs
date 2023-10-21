using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Rsoi.Lab2.ReservationService.Core;
using Rsoi.Lab2.ReservationService.Dto.Models;

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
    public async Task<IActionResult> CreateReservationAsync([FromBody][Required]CreateReservationRequest createReservationRequest)
    {
        var reservation = await _reservationRepository.CreateReservationAsync(
            createReservationRequest.Username,
            createReservationRequest.BooksId, 
            createReservationRequest.LibraryId, 
            createReservationRequest.TillDate);

        return Ok(reservation);
    }

    [HttpGet]
    [Route("user/{username}/reservations")]
    public async Task<IActionResult> GetReservationsForUserAsync([FromRoute][Required] string username)
    {
        var reservations = await _reservationRepository.GetReservationsForUserAsync(username);

        return Ok(reservations);
    }

    [HttpGet]
    [Route("reservations")]
    public async Task<IActionResult> GetReservationForCredentialsAsync(
        [FromBody][Required] GetReservationRequest getReservationRequest)
    {
        var reservation = await _reservationRepository.GetReservationForUserBookAndLibraryAsync(
            getReservationRequest.Username,
            getReservationRequest.BooksId,
            getReservationRequest.LibraryId);

        return Ok(reservation);
    }

    [HttpPost]
    [Route("reservations/{id}/close")]
    public async Task<IActionResult> CloseReservationAsync([FromRoute]Guid id, [FromQuery]DateOnly closeDate)
    {
        var reservation = await _reservationRepository.FindReservationAsync(id);

        if (reservation is null)
            return NotFound();

        var status = reservation.TillDate >= closeDate 
            ? ReservationStatus.Returned 
            : ReservationStatus.Expired;

        await _reservationRepository.UpdateReservationAsync(id, status);

        var response = new CloseReservationResponse((await _reservationRepository.FindReservationAsync(id))!,
            closeDate);

        return Ok(response);
    }
}