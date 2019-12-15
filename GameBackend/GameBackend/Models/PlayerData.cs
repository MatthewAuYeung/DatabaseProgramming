using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameBackend.Models
{
    public class PlayerData
    {
        public int idplayerdata { get; set; }
        public string username{ get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string date_of_birth { get; set; }
        public bool notification { get; set; }
    }
}