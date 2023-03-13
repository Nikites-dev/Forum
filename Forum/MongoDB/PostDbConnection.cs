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
        
        public static List<Post> FindUserPostsByUsername(String username)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Forum");
            var collection = database.GetCollection<Post>("Posts");
            var post = collection.Find(x => x.Username  == username).ToList();
            
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
        
        public static void UpdatePost(Post post)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Forum");
            var collection = database.GetCollection<Post>("Posts");
            var b = collection.ReplaceOne(x => x._id == post._id, post).ModifiedCount > 0;
        }
    }
}