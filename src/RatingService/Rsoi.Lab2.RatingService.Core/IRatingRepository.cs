namespace Rsoi.Lab2.RatingService.Core;

public interface IRatingRepository
{
    public Task<Guid> CreateRatingForUserAsync(string username, int stars);

    public Task<Rating?> FindRatingForUsernameAsync(string username);

    public Task EditRating(Guid id, int stars);
}