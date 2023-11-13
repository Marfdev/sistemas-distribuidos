using API_Incidencias.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace API_Incidencias
{
    public class Database
    {
        public int num;
        public static MongoClientSettings settings = MongoClientSettings.FromConnectionString("mongodb+srv://mrondon:0600101marf2003@mrondon-cluster-uneat.aytgptm.mongodb.net/?retryWrites=true&w=majority");
        //private MongoClientSettings settings.ServerApi = new ServerApi(ServerApiVersion.V1);
        public static IMongoClient client = new MongoClient(settings);
        public static IMongoDatabase database = client.GetDatabase("proyecto-incidencias");
        public static IMongoCollection<RoomModel> rooms = database.GetCollection<RoomModel>("rooms");
        public static IMongoCollection<IncidenceModel> incidences = database.GetCollection<IncidenceModel>("incidences");
        public static IMongoCollection<FloorModel> floors = database.GetCollection<FloorModel>("floors");
         
        //Floors
        public static List<FloorModel> getFloors()
        {
            return floors.Find(f=>true).ToList();
        }
        public static FloorModel getFloor(ObjectId id)
        {
            return floors.Find(f => f._id.Equals(id) ).ToList().First();
        }
        public static FloorModel createFloor (string name)
        {
            var floor = new FloorModel() { Name = name };
            floors.InsertOne(floor);
            return floors.Find(f => f._id.Equals(floor._id)).ToList().First();
        }
        public static FloorModel editFloor(ObjectId id, string name)
        {
            floors.UpdateOne(f => f._id.Equals(id), Builders<FloorModel>.Update.Set("name", name));
            return floors.Find(f => f._id.Equals(id)).ToList().First();
        }

        public static bool deleteFloor(ObjectId id)
        {
            floors.DeleteOne(f => f._id.Equals(id));
            bool deleted = floors.Find(f => f._id.Equals(id)).ToList().ToArray().Length == 0;
            return deleted ;
        }

        // Rooms
        public static List<RoomModel> getRooms()
        {
            return rooms.Find(f => true).ToList();
        }
        public static RoomModel getRoom(ObjectId id)
        {
            return rooms.Find(f => f.Id.Equals(id)).ToList().First();
        }
        public static RoomModel createRoom( RoomModel room)
        {
            rooms.InsertOne(room);
            return rooms.Find(f => f.Id.Equals(room.Id)).ToList().First();
        }
        public static RoomModel editRoom(ObjectId id, RoomModel room)
        {
            rooms.UpdateOne(f => f.Id.Equals(id), Builders<RoomModel>.Update.Set("name", room.Name).Set("ok", room.Ok).Set("type", room.Type).Set("floor_id", room.FloorId));
            return rooms.Find(f => f.Id.Equals(id)).ToList().First();
        }

        public static bool deleteRoom(ObjectId id)
        {
            rooms.DeleteOne(f => f.Id.Equals(id));
            bool deleted = rooms.Find(f => f.Id.Equals(id)).ToList().ToArray().Length == 0;
            return deleted;
        }

        // Incidences
        public static List<IncidenceModel> getIncidences()
        {
            return incidences.Find(f => true).ToList();
        }
        public static IncidenceModel getIncidence(ObjectId id)
        {
            return incidences.Find(f => f.Id.Equals(id)).ToList().First();
        }
        public static IncidenceModel createIncidence(IncidenceModel incidence)
        {
            incidences.InsertOne(incidence);
            return incidences.Find(f => f.Id.Equals(incidence.Id)).ToList().First();
        }
        public static IncidenceModel editIncidence(ObjectId id, IncidenceModel incidence)
        {
            incidences.UpdateOne(f => f.Id.Equals(id), Builders<IncidenceModel>.Update.Set("title", incidence.Title).Set("detail", incidence.Detail).Set("room_id", incidence.RoomId));
            return incidences.Find(f => f.Id.Equals(id)).ToList().First();
        }

        public static bool deleteIncidence(ObjectId id)
        {
            incidences.DeleteOne(f => f.Id.Equals(id));
            bool deleted = incidences.Find(f => f.Id.Equals(id)).ToList().ToArray().Length == 0;
            return deleted;
        }

    }
}