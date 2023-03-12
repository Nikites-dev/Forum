using System;
using System.Collections.Generic;
using Forum.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Forum.Models
{
    public class User
    {
        [BsonIgnoreIfDefault]
        public ObjectId _id;
        
        // public int Id { get; set; }
        public String NickName { get; set; }
        [BsonIgnoreIfDefault]
        public String FirstName { get; set; }
        [BsonIgnoreIfDefault]
        public String LastName { get; set; }
        [BsonIgnoreIfDefault]
        public String Email { get; set; }
        [BsonIgnoreIfDefault]
        public List<Post> posts { get; set; }
    }
}

