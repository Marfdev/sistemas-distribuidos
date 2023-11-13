using API_Incidencias.Models;
using Microsoft.Ajax.Utilities;
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
    public class FloorsController : ApiController
    {
        
        // GET api/floors
        public List<FloorModel> Get()
        {
            return Database.getFloors();
        }

        // GET api/floors/5
        public FloorModel Get(string id)
        {
            return Database.getFloor(new ObjectId(id));
        }

        // POST api/floors
        public FloorModel Post([FromBody] FloorModel floor)
        {
            return Database.createFloor(floor.Name);
            
        }

        // PUT api/floors/5
        public FloorModel Put(string id, [FromBody] FloorModel floor)
        {
            return Database.editFloor(new ObjectId(id), floor.Name);
        }

        // DELETE api/floors/5
        public bool Delete(string id)
        {
            return Database.deleteFloor(new ObjectId(id));
        }
    }
}
