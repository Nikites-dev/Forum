using System;
using System.Collections.Generic;
using Forum.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Forum.MongoDB
{
    public class PostDbConnection
    {
        public static void AddToDatabase(Post post)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Forum");
            var collection = database.GetCollection<Post>("Posts");
            collection.InsertOne(post);
        }
        
        
        public static Post FindPostByUsername(String username)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Forum");
            var collection = database.GetCollection<Post>("Posts");
            Post post = collection.Find(x => x.Username  == username).FirstOrDefault();
            
            if (post == null)
            {
                return null;
            }
            return post;
        }
        
        public static List<Post> FindPosts()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Forum");
            var collection = database.GetCollection<Post>("Posts");

            List<Post> post = new List<Post>();
            
            try
            {
                post = collection.Find(x => x.Username  != "").ToList();
            }
            catch (Exception e)
            {
                post = null;
            }
            
            if (post == null)
            {
                return null;
            }
            return post;
        }
        
        public static List<Post> FindUserPostsByUsername(String username)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Forum");
            var collection = database.GetCollection<Post>("Posts");

            List<Post> post = new List<Post>();
            
            try
            {
                post = collection.Find(x => x.Username == username).ToList();
            }
            catch (Exception e)
            {
                post = null;
            }
            
            if (post == null)
            {
                return null;
            }
            return post;
        }
        
        public static int FindUserLikesByUsername(String username)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Forum");
            var collection = database.GetCollection<Post>("Posts");

            List<Post> post = new List<Post>();
            int postLikes = 0;
            
            try
            {
                post = collection.Find(x => x.Username != "").ToList();

                for (int i = 0; i < post.Count; i++)
                {
                    var likes = post[i].Likes;
                    for (int j = 0; j < likes.Count; j++)
                    {
                        if (likes[j] == username)
                        {
                            postLikes++;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                post = null;
            }
            
            if (post == null)
            {
                return 0;
            }
            return postLikes;
        }
        
        
        public static int FindUserCommentsByUsername(String username)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Forum");
            var collection = database.GetCollection<Post>("Posts");

            List<Post> post = new List<Post>();
            int postLikes = 0;
            
            try
            {
                post = collection.Find(x => x.Username != "").ToList();

                for (int i = 0; i < post.Count; i++)
                {
                    List<Comment> comments = post[i].Comments;
                    for (int j = 0; j < comments.Count; j++)
                    {
                        if (comments[j].Username == username)
                        {
                            postLikes++;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                post = null;
            }
            
            if (post == null)
            {
                return 0;
            }
            return postLikes;
        }
        
        public static List<Post> FindUserPostsByInterest(String interest)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Forum");
            var collection = database.GetCollection<Post>("Posts");

            List<Post> post = new List<Post>();
            
            try
            {
                post = collection.Find(x => x.Interest == interest).ToList();
            }
            catch (Exception e)
            {
                post = null;
            }
            
            if (post == null)
            {
                return null;
            }
            return post;
        }
        
        public static void UpdatePost(Post post)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Forum");
            var collection = database.GetCollection<Post>("Posts");
            var b = collection.ReplaceOne(x => x._id == post._id, post).ModifiedCount > 0;
        }
        
        public static void DeletePost(Post post)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Forum");
            var collection = database.GetCollection<Post>("Posts");
            var unit = collection.DeleteOne(x => x._id == post._id);
        }
    }
}