using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    public void FillProfile(string username, string first_name, string last_name, string email, string date_of_birth, bool notification)
    {
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

    public bool IsFound = false;
}