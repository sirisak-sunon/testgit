using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookstorController : ControllerBase
    {

        IMongoCollection<BookstoreModel> bookstroe {get; set;}

        public BookstorController(){
            var connecdb = MongoClientSettings.FromUrl(new MongoUrl("mongodb://sirisak:sirisak022602020@ds125352.mlab.com:25352/mendb"));
            var mongoclient = new MongoClient(connecdb);
            var database = mongoclient.GetDatabase("mendb");

            bookstroe = database.GetCollection<BookstoreModel>("bookstroe");
        }
        

        [HttpGet("[action]")]
        public IEnumerable<BookstoreModel> GetBookstore()
        {
            return bookstroe.Find(data => true).ToList();
        }

        [HttpPost("[action]")]
        public void insertbook([FromBody]BookstoreModel data){
            /* data.Id = Guid.NewGuid().ToString(); */
            bookstroe.InsertOne(data);
        }

        [HttpPost("[action]")]
        public void updatebook([FromBody]BookstoreModel data){
            bookstroe.ReplaceOne(it => it.Id == data.Id ,data);
        }

       [HttpPost("[action]")]
        public void deletebook(string id){
            bookstroe.DeleteOne(it => it.Id == id);
        }
    }
}
