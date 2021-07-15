using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consume.Models
{
    public class Projects
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProjectId { get; set; }
        public string ProjectName { get; set; }
        
    }
}
