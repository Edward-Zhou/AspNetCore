using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace EFCorePro.Controllers
{
    [Produces("application/json")]
    [Route("api/MongoDb")]
    public class MongoDbController : Controller
    {
        private readonly IMongoDatabase _mongoDatabase;
        public MongoDbController(IMongoDatabase mongoDatabase)
        {
            _mongoDatabase = mongoDatabase;
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult<string> Get()
        {
            //fetch results using filter from Test_Collection 
            var results = _mongoDatabase.GetCollection<BsonDocument>("Products").Find(_ => true).FirstOrDefault();

            string final = results.ToJson();
            return final.ToString();
        }
        [HttpPost]
        [Route("[action]")]
        public ActionResult<string> GetAll()
        {
            //fetch results using filter from Test_Collection 
            var results = _mongoDatabase.GetCollection<BsonDocument>("Products").Find(_ => true).ToList();

            string final = results.ToJson();
            return final.ToString();
        }

    }
}