using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackEndManager : MonoBehaviour
{
    // Singleton
    private static BackEndManager instance = null;
    public static BackEndManager Instance()
    {
        return instance;
    }
    //--------------------------------------------------------------
    // public members
    public string SQL_PLAYER_BASE_URL = "http://localhost:50531/api/SQLPlayerData/";
    public string SQL_MATCH_BASE_URL = "http://localhost:50531/api/SQLMatchData/";
    public string NOSQL_PLAYER_BASE_URL = "http://localhost:50531/api/NoSQLPlayerData/";
    public string NOSQL_MATCH_BASE_URL = "http://localhost:50531/api/NoSQLMatchData/";

    public bool IsPlayerDataRecieved = false;
    public bool IsMatchDataRecieved = false;

    public PlayerData playerData;
    public List<MatchData> matchDatas;
    public string RawData;
    //--------------------------------------------------------------
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;

            playerData = new PlayerData();
            matchDatas = new List<MatchData>();
        }
        else
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
