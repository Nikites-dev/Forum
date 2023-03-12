using System;
using System.Collections.Generic;
using Forum.Models;
using Forum.MongoDB;

namespace Forum.Services
{
    public class PostService
    {
        // public static List<Comment> comments = new()
        // {
        //     new Comment{UserId = 1, Rating = 12, Text = "Cool"},
        //     new Comment{UserId = 13, Rating = 22, Text = "Text"},
        //     new Comment{UserId = 134, Rating = 142, Text = "Cool"},
        //     new Comment{UserId = 11, Rating = 42, Text = "Cool"},
        // };
        // // error
        // public List<Post> _posts = new()
        // {
        //     new Post
        //     { 
        //         UserId = 1, Comments = comments, Rating = 123, Text = "COOL!!!", CreatePost = DateTime.Now, Likes = new List<int>(){1, 21,13}
        //     },
        //     new Post
        //     { 
        //         UserId = 2, Comments = comments, Rating = 123, Text = "COOL!!!", CreatePost = DateTime.Now, Likes = new List<int>(){1, 21,13}
        //     }
        // };


        public List<Post> posts = new List<Post>();
        
        
            
        public List<Post> GetPosts() {
        
            return posts = PostDbConnection.FindPosts();
        }

        public void AddPost(Post post)
        {
            posts.Add(post);
        }
    }
}

