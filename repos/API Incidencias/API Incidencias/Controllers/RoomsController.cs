using API_Incidencias.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MongoDB.Bson;
using System.Web.Http.Cors;

namespace API_Incidencias.Controllers
{
    [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
    public class RoomsController : ApiController
    {
        
        // GET: api/Rooms
        public List<RoomModel> Get()
        {
            return Database.getRooms();
        }

        // GET: api/Rooms/5
        public RoomModel Get(string id)
        {
            return Database.getRoom(new ObjectId(id));
        }

        // POST: api/Rooms
        public RoomModel Post([FromBody] RoomDTO req)
        {
             return Database.createRoom(new RoomModel() { Name = req.Name, Ok = req.Ok, Type = req.Type, FloorId = new ObjectId(req.FloorId) });
        }

        // PUT: api/Rooms/5
        public RoomModel Put(string id, [FromBody] RoomDTO req)
        {
            return Database.editRoom(new ObjectId(id), new RoomModel() { Name = req.Name, Ok = req.Ok, Type = req.Type, FloorId = new ObjectId(req.FloorId) });
        }

        // DELETE: api/Rooms/5
        public bool Delete(string id)
        {
            return Database.deleteRoom(new ObjectId(id));
        }
    }
}
