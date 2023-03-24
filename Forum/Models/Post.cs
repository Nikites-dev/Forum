using System;
using System.Collections.Generic;
using Forum.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Forum.Models
{
    public class Post
    {
        [BsonIgnoreIfDefault]
        public ObjectId _id;
        
        [BsonIgnoreIfDefault]
        public String Username { get; set; }
        
        [BsonIgnoreIfDefault]
        public String Text { get; set; }
        
        [BsonIgnoreIfDefault]
        public DateTime CreatePost { get; set; }
        
        [BsonIgnoreIfDefault]
        public String? NameImage { get; set; }
        
        [BsonIgnoreIfDefault]
        public List<Comment> Comments { get; set; }
        
        [BsonIgnoreIfDefault]
        public List<String> Likes { get; set; }
        
        [BsonIgnoreIfDefault]
        public String Interest { get; set; }
    }
}

