using System;
using Forum.Models;
using MongoDB.Driver;

namespace Forum.MongoDB
{
    public class UserDbConnection
    {
        public User? isLoginUser { get; set; }
        public static void AddToDatabase(User user)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Forum");
            var collection = database.GetCollection<User>("Users");
            collection.InsertOne(user);
        }
        
        
        public static User GetUserByUsernamePassword(String username, String passwerd)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Forum");
            var collection = database.GetCollection<User>("Users");
            User user = collection.Find(x => x.Username  == username && x.Password == passwerd).FirstOrDefault();
            
            if (user == null)
            {
                return null;
            }
            return user;
        }
        
        
        public static bool ExistsUser(String username)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Forum");
            var collection = database.GetCollection<User>("Users");
            User user = collection.Find(x => x.Username  == username).FirstOrDefault();
            
            if (user == null)
            {
                return false;
            }
            return true;
        }
        
        public static void UpdateUser(User user)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Forum");
            var collection = database.GetCollection<User>("Users");
            var b = collection.ReplaceOne(x => x.Username == user.Username, user).ModifiedCount > 0;
        }
    }
}