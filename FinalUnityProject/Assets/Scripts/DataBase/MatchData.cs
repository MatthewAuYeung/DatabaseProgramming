using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchData
{
    public MatchData(int idmatchdata,int playerdata_idplayerdata,int score,string date_of_match)
    {
        this.idmatchdata = idmatchdata;
        this.playerdata_idplayerdata = playerdata_idplayerdata;
        this.score = score;
        this.date_of_match = date_of_match;
    }
    public int idmatchdata;
    public int playerdata_idplayerdata;
    public int score;
    public string date_of_match;
}
