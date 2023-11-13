using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project_api_attempt.Models
{
    public class MongoDBSettings
    {
        public string ConnectionURI { get; set; } = null;
        public string DatabaseName { get; set; } = null;
        public string CollectionName { get; set; } = null;
    }
}