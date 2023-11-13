using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_Incidencias.Models
{
    public class FloorModel
    {
        [BsonId]
        public ObjectId _id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }


    }
}