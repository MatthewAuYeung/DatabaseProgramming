using GameBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

using MongoDB.Bson;
using MongoDB.Driver;

namespace GameBackend.Controllers
{
    public class NoSQLMatchDataController : ApiController
    {
        public IHttpActionResult GetNoSQLMatchData(int playerid)
        {
            try
            {
                var connectionString = "mongodb://localhost";
                var client = new MongoClient(connectionString);
                var database = client.GetDatabase("matchdata");
                var collection = database.GetCollection<BsonDocument>("matchdatas");

                var filterBuilder = Builders<BsonDocument>.Filter;
                var filter = filterBuilder.Eq("idplayerdata", playerid);
                var cursor = collection.Find(filter).Limit(10).ToCursor().ToEnumerable();
                return Ok(cursor);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return NotFound();
            }
        }

        public IHttpActionResult GetNoSQLMatchData(string date1, string date2)
        {
            try
            {
                var connectionString = "mongodb://localhost";
                var client = new MongoClient(connectionString);
                var database = client.GetDatabase("matchdata");
                var collection = database.GetCollection<BsonDocument>("matchdatas");

                var filterBuilder = Builders<BsonDocument>.Filter;
                var filter = filterBuilder.Gte("date_of_match", date1) & filterBuilder.Lte("date_of_match", date2);
                var sort = Builders<BsonDocument>.Sort.Descending("score");

                var cursor = collection.Find(filter).Limit(10).Sort(sort).ToCursor().ToEnumerable();
                return Ok(cursor);
         }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return NotFound();
            }
        }
        public IHttpActionResult DeleteNoSQLMatchData(int playerid)
        {
            try
            {
                var connectionString = "mongodb://localhost";
                var client = new MongoClient(connectionString);
                var database = client.GetDatabase("matchdata");
                var collection = database.GetCollection<BsonDocument>("matchdatas");

                var filter = Builders<BsonDocument>.Filter.Eq("idplayerdata", playerid);
                collection.DeleteOne(filter);

                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return NotFound();
            }

        }

        public IHttpActionResult PutNoSQLMatchData(MatchData match)
        {
            try
            {
                var connectionString = "mongodb://localhost";
                var client = new MongoClient(connectionString);

                var database = client.GetDatabase("matchdata");
                var collection = database.GetCollection<BsonDocument>("matchdatas");
                var matchData = new BsonDocument
                {
                    { "idplayerdata", match.idplayerdata.ToString() },
                    { "score", match.score.ToString() },
                    { "date_of_match", match.date_of_match.ToString() }
                };
                collection.InsertOne(matchData);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return NotFound();
            }
        }
    }
}