using System;
using System.Collections.Generic;

namespace Forum.Models
{
    public class Interests
    {
        public static List<String> GetListInterest()
        {
            List<String> listInerests = new List<string>
            {
                "Funny",
                "Sport",
                "Lifehacks",
                "Animals",
                "Gaming",
                "TV",
                "Music",
                "IT",
                "Cooking",
                "Travel",
                "Cars",
                "Finance",
                "Opinions",
            };
            return listInerests;
        }
    }
}