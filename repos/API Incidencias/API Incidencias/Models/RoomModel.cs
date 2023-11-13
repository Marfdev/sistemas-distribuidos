using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_Incidencias.Models
{
    public class RoomModel
    {
        [BsonId]
        // [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("type")]
        public string Type { get; set; }

        [BsonElement("ok")]
        public bool Ok { get; set; }

        [BsonElement("floor_id")]
        // [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId FloorId { get; set; }
    }
}