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
    public class NoSQLPlayerDataController : ApiController
    {
        public IHttpActionResult GetNoSQLPlayerData(string username)
        {
            try
            {
                var connectionString = "mongodb://localhost";
                var client = new MongoClient(connectionString);
                var database = client.GetDatabase("playerdata");
                var collection = database.GetCollection<BsonDocument>("playerdatas");

                var filter = Builders<BsonDocument>.Filter.Eq("username", username);
                var cursor = collection.Find(filter).ToCursor();
                foreach (var playerData in cursor.ToEnumerable())
                {
                    return Ok(playerData);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return NotFound();
            }
            return NotFound();
        }

        public IHttpActionResult GetNoSQLPlayerData(int playerid)
        {
            try
            {
                var connectionString = "mongodb://localhost";
                var client = new MongoClient(connectionString);
                var database = client.GetDatabase("playerdata");
                var collection = database.GetCollection<BsonDocument>("playerdatas");

                var filter = Builders<BsonDocument>.Filter.Eq("idplayerdata", playerid);
                var cursor = collection.Find(filter).ToCursor();
                foreach (var playerData in cursor.ToEnumerable())
                {
                    return Ok(playerData);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return NotFound();
            }
            return NotFound();
        }

        public IHttpActionResult PutNoSQLPlayerData(PlayerData player)
        {
            try
            {
                var connectionString = "mongodb://localhost";
                var client = new MongoClient(connectionString);

                var database = client.GetDatabase("playerdata");
                var collection = database.GetCollection<BsonDocument>("playerdatas");
                var playerData = new BsonDocument
                {
                    { "username", player.username.ToString() },
                    { "first_name", player.first_name.ToString() },
                    { "last_name", player.last_name.ToString() },
                    { "email", player.email.ToString() },
                    { "date_of_birth", player.date_of_birth.ToString() },
                    { "notification", player.notification }
                };
                collection.InsertOne(playerData);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return NotFound();
            }
        }

        public IHttpActionResult DeleteNoSQLPlayerData(string username)
        {
            try
            {
                var connectionString = "mongodb://localhost";
                var client = new MongoClient(connectionString);
                var database = client.GetDatabase("playerdata");
                var collection = database.GetCollection<BsonDocument>("playerdatas");

                var filter = Builders<BsonDocument>.Filter.Eq("username", username);
                collection.DeleteOne(filter);

                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return NotFound();
            }
        }

        public IHttpActionResult PostNoSQLPlayerData(PlayerData player, bool useid)
        {
            try
            {
                var connectionString = "mongodb://localhost";
                var client = new MongoClient(connectionString);
                var database = client.GetDatabase("playerdata");
                var collection = database.GetCollection<BsonDocument>("playerdatas");

                var filterUsername = Builders<BsonDocument>.Filter.Eq("username", player.username);
                var filterId = Builders<BsonDocument>.Filter.Eq("idplayerdata", player.username);
                var update = Builders<BsonDocument>.Update.
                    Set("username", player.username).
                    Set("first_name", player.first_name).
                    Set("last_name", player.last_name).
                    Set("email", player.email).
                    Set("date_of_birth", player.date_of_birth).
                    Set("notification", player.notification);

                if(useid)
                {
                    collection.UpdateOne(filterId, update);
                }
                else
                {
                    collection.UpdateOne(filterUsername, update);
                }
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
