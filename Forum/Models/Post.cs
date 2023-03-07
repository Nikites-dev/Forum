namespace Forum.Models;

public class Post
{
    public int UserId { get; set; }
    public String Text { get; set; }
    public DateTime CreatePost { get; set; }
    public List<Comment> Comments { get; set; }
    
    public List<int> Likes { get; set; }
    public int Rating { get; set; }

   
}