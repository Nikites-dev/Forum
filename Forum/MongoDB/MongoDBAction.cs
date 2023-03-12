using System;
using System.Collections.Generic;
using Forum.Models;
using MongoDB.Driver;

namespace Forum.MongoDB
{
    public class MongoDBAction
    {
        public static void AddToDatabase(Post post)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Forum");
            var collection = database.GetCollection<Post>("Posts");
            collection.InsertOne(post);
        }
        
        
        public static Post FindPostByUserId(int userId)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Forum");
            var collection = database.GetCollection<Post>("Posts");
            Post post = collection.Find(x => x.UserId  == userId).FirstOrDefault();
            
            if (post == null)
            {
                return null;
            }
            return post;
        }
        
        public static List<Post> FindUserPostsByUserId(int userId)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Forum");
            var collection = database.GetCollection<Post>("Posts");
            var post = collection.Find(x => x.UserId  == userId).ToList();
            
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
               post = collection.Find(x => x.UserId  > 0).ToList();
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
        
        
        // public static User FindPostByUserId(String login, String password)
        // {
        //     var client = new MongoClient("mongodb://localhost");
        //     var database = client.GetDatabase("Users");
        //     var collection = database.GetCollection<User>("UsersData");
        //     User user = collection.Find(x => x.Login  == login).FirstOrDefault();
        //     
        //
        //     if (user == null)
        //     {
        //         return null;
        //     }
        //
        //     if (user.Password == password)
        //     {
        //         return user;
        //     }
        //     return null;
        // }
        
        
        
        
        //     switch (unit.ClassName)
        //     {
        //         case "Warrior":
        //             return new Warrior(unit.Strength,
        //                 unit.Dexterity,
        //                 unit.Constitution,
        //                 unit.Intellisense,
        //                 unit.Items, 
        //                 unit.Exp, 
        //                 unit.Equipments)
        //             { Name = unit.Name};
        //         
        //         case "Wizard":
        //             return new Wizard(unit.Strength,
        //                     unit.Dexterity,
        //                     unit.Constitution,
        //                     unit.Intellisense,
        //                     unit.Items,
        //                     unit.Exp,
        //                     unit.Equipments)
        //                 {Name = unit.Name};
        //         
        //         case "Rogue":
        //             return new Rogue(unit.Strength,
        //                     unit.Dexterity,
        //                     unit.Constitution,
        //                     unit.Intellisense, 
        //                     unit.Items,
        //                     unit.Exp,
        //                     unit.Equipments)
        //                 {Name = unit.Name};
        //         default: return null;
        //     }
        //     return null;
        // }
        //
        // public static String DeleteByName(String name)
        // {
        //     var client = new MongoClient("mongodb://localhost");
        //     var database = client.GetDatabase("Warcraft");
        //     var collection = database.GetCollection<Unit>("HeroCollection");
        //     var unit = collection.DeleteOne(x => x.Name == name);
        //     return $"Unit {unit.GetType().Name} is remove!";
        // }
        //
        // public static void ClearDB()
        // {
        //     var client = new MongoClient("mongodb://localhost");
        //     client.GetDatabase("Warcraft").DropCollectionAsync("HeroCollection");
        // }
        //
        // public static List<String> AddListHeroes()
        // {
        //     var client = new MongoClient("mongodb://localhost");
        //     var database = client.GetDatabase("Warcraft");
        //     var collection = database.GetCollection<CharacterDb>("HeroCollection");
        //     var strNames = collection.Find<CharacterDb>(x => x.Name != null && x.Name != "")
        //         .ToEnumerable<CharacterDb>();
        //     return strNames.Select(x => x.Name).ToList<String>();
        // }
        //
        // public static void UpdateByName(String name, Unit unit)
        // {
        //     var client = new MongoClient("mongodb://localhost");
        //     var database = client.GetDatabase("Warcraft");
        //     var collection = database.GetCollection<CharacterDb>("HeroCollection");
        //     var b = collection.ReplaceOne(x => x.Name == name, UnitToCharacter(name, unit)).ModifiedCount > 0;
        // }
    }
}