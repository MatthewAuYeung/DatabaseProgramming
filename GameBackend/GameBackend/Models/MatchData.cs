using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameBackend.Models
{
    public class MatchData
    {
        public int idmatchdata { get; set; }
        public int idplayerdata { get; set; }
        public int score { get; set; }
        public string date_of_match { get; set; }
    }
}