using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_Incidencias.Models
{
    public class IncidenceDTO
    {
        [BsonId]
        // [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("detail")]
        public string Detail { get; set; }

        [BsonElement("room_id")]
        // [BsonRepresentation(BsonType.ObjectId)]
        public string RoomId { get; set; }
    }
}