using System;
using System.Collections.Generic;
using Forum.Models;
using MongoDB.Driver;

namespace Forum.MongoDB
{
    public class MongoDBAction
    {

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