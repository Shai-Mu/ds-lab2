using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Rsoi.Lab2.RatingService.Core;
using Rsoi.Lab2.RatingService.Dto.Models;

namespace Rsoi.Lab2.RatingService.HttpApi.Controllers;

public class RatingsController : ControllerBase
{
    private readonly IRatingRepository _ratingRepository;

    public RatingsController(IRatingRepository ratingRepository)
    {
        _ratingRepository = ratingRepository;
    }
    
    [HttpGet]
    [Route("ratings")]
    public async Task<IActionResult> FindRatingByNameAsync([FromQuery]string username)
    {
        var rating = await _ratingRepository.FindRatingForUsernameAsync(username);

        return Ok(new RatingResponse(rating));
    }

    [HttpPost]
    [Route("ratings")]
    public async Task<IActionResult> CreateRating([FromBody]CreateRatingRequest createRatingRequest)
    {
        var ratingId = await _ratingRepository.CreateRatingForUserAsync(createRatingRequest.Username, createRatingRequest.Stars);

        return Ok(ratingId);
    }

    [HttpPatch]
    [Route("ratings/{id}")]
    public async Task<IActionResult> EditRatingForUser([FromRoute] Guid id, [FromQuery]int stars)
    {
        int normalizedStars = stars switch
        {
            > 100 => 100,
            < 1 => 1,
            _ => stars
        };

        await _ratingRepository.EditRatingAsync(id, normalizedStars);

        return Ok();
    }
}