using GameBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using GameBackend.SQLDatabase;

namespace GameBackend.Controllers
{
    public class SQLPlayerDataController : ApiController
    {
        public IHttpActionResult Get(string username)
        {
            GetSQLPlayerByUsername getSQLPlayer = new GetSQLPlayerByUsername();
            try
            {
                getSQLPlayer.playerData = new PlayerData();
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

        public IHttpActionResult Get(int playerid)
        {
            GetSQLPlayerByID getSQLPlayer = new GetSQLPlayerByID();
            try
            {
                getSQLPlayer.playerData = new PlayerData();
                getSQLPlayer.playerData.idplayerdata = playerid;
                getSQLPlayer.execute();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return NotFound();
            }
            return Ok(getSQLPlayer.playerData);
        }

        public IHttpActionResult Post(PlayerData player)
        {
            AddSQLPlayer addSQLPlayer = new AddSQLPlayer();
            try
            {
                addSQLPlayer.playerData = new PlayerData();
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

        public IHttpActionResult Delete(string username)
        {
            DeleteSQLPlayer deleteSQLPlayer = new DeleteSQLPlayer();
            try
            {
                deleteSQLPlayer.playerData = new PlayerData();
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
            UpdateSQLPlayer updateSQLPlayer = new UpdateSQLPlayer();
            try
            {
                updateSQLPlayer.playerData = new PlayerData();
                updateSQLPlayer.playerData = player;
                updateSQLPlayer.execute();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return NotFound();
            }
            return Ok(updateSQLPlayer.playerData);
        }
    }
}
