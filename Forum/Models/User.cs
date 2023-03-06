namespace Forum.Models;

public class User
{
    
    public int Id { get; set; }
    public String NickName { get; set; }
    public String FirstName { get; set; }
    public String LastName { get; set; }
    public String Email { get; set; }
    
    public List<Post> posts { get; set; }
    
}