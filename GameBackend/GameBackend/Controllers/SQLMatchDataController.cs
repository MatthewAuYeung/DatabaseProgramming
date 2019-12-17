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
    public class SQLMatchDataController : ApiController
    {
        public IHttpActionResult Get(int playerid)
        {
            GetSQLMatchByID getSQLMatchByID = new GetSQLMatchByID();
            try
            {
                getSQLMatchByID.matchData = new MatchData();

                getSQLMatchByID.matchData.playerdata_idplayerdata = playerid;
                getSQLMatchByID.execute();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return NotFound();
            }
            return Ok(getSQLMatchByID.matchDatas);
        }

        public IHttpActionResult Get(string date1, string date2)
        {
            GetSQLMatchByDates getSQLMatchByDates = new GetSQLMatchByDates();
            try
            {
                getSQLMatchByDates.matchData = new MatchData();

                getSQLMatchByDates.start_date = date1;
                getSQLMatchByDates.end_date = date2;

                getSQLMatchByDates.execute();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return NotFound();
            }
            return Ok(getSQLMatchByDates.matchDatas);
        }

        public IHttpActionResult Delete(int playerid)
        {
            DeleteSQLMatch deleteSQLMatch = new DeleteSQLMatch();
            try
            {
                deleteSQLMatch.matchData = new MatchData();

                deleteSQLMatch.matchData.playerdata_idplayerdata = playerid;
                deleteSQLMatch.execute();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return NotFound();
            }
            return Ok();
        }

        public IHttpActionResult Post(MatchData match)
        {
            AddSQLMatch addSQLMatch = new AddSQLMatch();
            try
            {
                addSQLMatch.matchData = new MatchData();

                addSQLMatch.matchData = match;
                addSQLMatch.execute();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return NotFound();
            }
            return Ok(addSQLMatch.matchData);
        }
    }
}
