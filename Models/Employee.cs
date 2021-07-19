using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace Consume.Models
{
    public class Employee
    {
       
          
           
            public string EmpId { get; set; }
            public string EMPName { get; set; }
            public string EmailId { get; set; }
            public string MobileNo { get; set; }
            public List<string> ProjectID { get; set; }

            public List<string> TeamId { get; set; }



        
    }
    public class Emp : Employee
    {

        [BsonRepresentation(BsonType.ObjectId)]

        [BsonIgnore]
        public List<Projects> ProjectsList { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnore]
        public List<Team> TeamList { get; set; }
    }
}
