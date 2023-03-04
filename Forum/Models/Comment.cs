namespace Forum.Models;

public class Comment
{
    public User User { get; set; }
    public String Text { get; set; }
    public int Rating { get; set; }
}