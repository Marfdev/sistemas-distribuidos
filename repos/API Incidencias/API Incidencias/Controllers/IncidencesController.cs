using API_Incidencias.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using MongoDB.Bson;

namespace API_Incidencias.Controllers
{
    [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
    public class IncidencesController : ApiController
    {
        
        // GET: api/Incidences
        public List<IncidenceModel> Get()
        {
            return Database.getIncidences();
        }

        // GET: api/Incidences/5
        public IncidenceModel Get(string id)
        {
            return Database.getIncidence( new ObjectId(id));
        }

        // POST: api/Incidences
        public IncidenceModel Post([FromBody]IncidenceDTO req)
        {
            return Database.createIncidence(new IncidenceModel() { Title = req.Title, Detail = req.Detail, RoomId = new ObjectId(req.RoomId) });
        }

        // PUT: api/Incidences/5
        public IncidenceModel Put(string id, [FromBody]IncidenceDTO req)
        {
            return Database.editIncidence(new ObjectId(id), new IncidenceModel() { Title = req.Title, Detail = req.Detail, RoomId = new ObjectId(req.RoomId) });
        }

        // DELETE: api/Incidences/5
        public bool Delete(string id)
        {
            return Database.deleteIncidence(new ObjectId(id));
        }
    }
}
