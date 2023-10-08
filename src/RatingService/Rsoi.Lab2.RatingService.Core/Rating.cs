namespace Rsoi.Lab2.RatingService.Core;

public class Rating
{
    public Guid Id { get; }
    
    public string Username { get; }
    
    public int Stars { get; }

    public Rating(Guid id, 
        string username, 
        int stars)
    {
        Id = id;
        Username = username;
        Stars = stars;
    }
}