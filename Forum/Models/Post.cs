namespace Forum.Models;

public class Post
{
    public String Text { get; set; }
    public DateTime CreatePost { get; set; }
    public List<Comment> Comments { get; set; }
    public int Rating { get; set; }
}