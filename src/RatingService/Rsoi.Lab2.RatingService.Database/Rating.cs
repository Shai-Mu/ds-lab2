namespace Rsoi.Lab2.RatingService.Database;

public class Rating
{
    public Guid Id { get; set; }
    
    public string Username { get; set; }
    
    public int Stars { get; set; }

    public Rating(Guid id, 
        string username, 
        int stars)
    {
        Id = id;
        Username = username;
        Stars = stars;
    }
}