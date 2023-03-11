using Forum.Models;

namespace Forum.Services;

public class PostService
{
   
   public static List<Post> GetPosts() {
       List<Comment> comments = new()
      {
         new Comment{UserId = 1, Rating = 12, Text = "Cool"},
         new Comment{UserId = 13, Rating = 22, Text = "Text"},
         new Comment{UserId = 134, Rating = 142, Text = "Cool"},
         new Comment{UserId = 11, Rating = 42, Text = "Cool"},
      };
      // error
      List<Post> _posts = new()
      {
         new Post
         { 
            UserId = 1, Comments = comments, Rating = 123, Text = "COOL!!!", CreatePost = DateTime.Now, Likes = new List<int>(){1, 21,13}
         },
         new Post
         { 
            UserId = 2, Comments = comments, Rating = 123, Text = "COOL!!!", CreatePost = DateTime.Now, Likes = new List<int>(){1, 21,13}
         }
      };
      return _posts;
   }
}