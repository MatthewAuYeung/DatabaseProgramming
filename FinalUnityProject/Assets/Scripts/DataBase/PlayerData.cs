using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    public PlayerData(int idplayer, string username, string first_name, string last_name, string email, string date_of_birth, bool notification)
    {
        this.idplayer = idplayer;
        this.username = username;
        this.first_name = first_name;
        this.last_name = last_name;
        this.email = email;
        this.date_of_birth = date_of_birth;
        this.notification = notification;
    }

    public int idplayer;
    public string username;
    public string first_name;
    public string last_name;
    public string email;
    public string date_of_birth;
    public bool notification;
}

public class Data
{
  static public int id { get; set; }
  static public string userNmae { get; set; }
  static public string firstName { get; set; }
  static public string lastName { get; set; }
  static public string dob { get; set; }
  static public string email { get; set; }
  static public bool notification { get; set; }
}


