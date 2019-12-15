using GameBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using GameBackend.Database;

namespace GameBackend.Controllers
{
    public class SQLPlayerDataController : ApiController
    {
        public IHttpActionResult Get(string username)
        {
            GetSQLPlayer getSQLPlayer = new GetSQLPlayer();
            try
            {
                getSQLPlayer.playerData.username = username;
                getSQLPlayer.execute();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return NotFound();
            }
            return Ok(getSQLPlayer.playerData);
        }

        public IHttpActionResult Post(string username)
        {
            UpdateSQLPlayer updateSQLPlayer = new UpdateSQLPlayer();
            try
            {
                updateSQLPlayer.playerData.username = username;
                updateSQLPlayer.execute();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return NotFound();
            }
            return Ok(updateSQLPlayer.playerData);
        }

        public IHttpActionResult Delete(string username)
        {
            DeleteSQLPlayer deleteSQLPlayer = new DeleteSQLPlayer();
            try
            {
                deleteSQLPlayer.playerData.username = username;
                deleteSQLPlayer.execute();                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return NotFound();
            }
            return Ok(deleteSQLPlayer.playerData);
        }

        public IHttpActionResult Put(PlayerData player)
        {
            AddSQLPlayer addSQLPlayer = new AddSQLPlayer();
            try
            {
                addSQLPlayer.playerData = player;
                addSQLPlayer.execute();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return NotFound();
            }
            return Ok(addSQLPlayer.playerData);
        }
    }
}
