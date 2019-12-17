using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SQLWebClient : WebClient
{
    public override IEnumerator GetPlayerByUsername(string username)
    {
        BackEndManager.Instance().IsPlayerDataRecieved = false;
        string uri = BackEndManager.Instance().SQL_PLAYER_BASE_URL + "Get?username=" + username;
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError)
            {
                Debug.Log(uri + " Error: " + webRequest.error);
            }
            else
            {
                Debug.Log(uri + " Received: " + webRequest.downloadHandler.text);
                BackEndManager.Instance().playerData = JsonUtility.FromJson<PlayerData>(webRequest.downloadHandler.text);
                BackEndManager.Instance().IsPlayerDataRecieved = true;
                GameLoader.playerID = BackEndManager.Instance().playerData.idplayerdata;
            }
        }
    }

    public override IEnumerator GetPlayerByID(int id)
    {
        BackEndManager.Instance().IsPlayerDataRecieved = false;
        string uri = BackEndManager.Instance().SQL_PLAYER_BASE_URL + "Get?playerid=" + id.ToString();
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError)
            {
                Debug.Log(uri + " Error: " + webRequest.error);
            }
            else
            {
                Debug.Log(uri + " Received: " + webRequest.downloadHandler.text);
                var temp = JsonUtility.FromJson<PlayerData>(webRequest.downloadHandler.text);
                BackEndManager.Instance().playerDatas.Add(temp);
                BackEndManager.Instance().IsPlayerDataRecieved = true;
            }
        }
    }

    public override IEnumerator UpdatePlayerProfile(PlayerData PlayerData)
    {
        string uri = BackEndManager.Instance().SQL_PLAYER_BASE_URL +"Put";
        string jsonData = JsonUtility.ToJson(PlayerData);

        UnityWebRequest webRequest = new UnityWebRequest(uri, "Put");

        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(jsonData);
        webRequest.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        webRequest.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        webRequest.SetRequestHeader("Content-Type", "application/json");
        yield return webRequest.SendWebRequest();

        if (webRequest.isNetworkError)
        {
            Debug.Log(uri + " Error: " + webRequest.error);
        }
        else
        {
            Debug.Log(uri + " Received: " + webRequest.downloadHandler.text);
        }
    }

    public override IEnumerator DeletePlayer(string username)
    {
        string uri = BackEndManager.Instance().SQL_PLAYER_BASE_URL + "Delete?username="+username;

        UnityWebRequest webRequest = UnityWebRequest.Delete(uri);
        yield return webRequest.SendWebRequest();

        if (webRequest.isNetworkError)
        {
            Debug.Log(uri + " Error: " + webRequest.error);
        }
        else
        {
            Debug.Log(uri);
        }
    }

    public override IEnumerator AddPlayer(PlayerData playerData)
    {
        string uri = BackEndManager.Instance().SQL_PLAYER_BASE_URL + "Post";
        string jsonData = JsonUtility.ToJson(playerData);

        UnityWebRequest webRequest = new UnityWebRequest(uri, "Post");

        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(jsonData);
        webRequest.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        webRequest.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        webRequest.SetRequestHeader("Content-Type", "application/json");

        yield return webRequest.SendWebRequest();

        if (webRequest.isNetworkError)
        {
            Debug.Log(uri + " Error: " + webRequest.error);
        }
        else
        {
            Debug.Log(uri + " Received: " + webRequest.downloadHandler.text);
        }
    }

    //-------------------------------------------------------------------------------------------------------------
    [Serializable]
    public class RootObject
    {
        public MatchData[] rootData;
    }

    public override IEnumerator GetMatchesByPlayerID(int player_id)
    {
        BackEndManager.Instance().IsMatchDataRecieved = false;
        BackEndManager.Instance().matchDatas.Clear();
        //string uri = BackEndManager.Instance().SQL_MATCH_BASE_URL + "Get?playerdata_idplayerdata=" + player_id.ToString();
        string uri = BackEndManager.Instance().SQL_MATCH_BASE_URL + "Get?playerid=" + player_id;
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError)
            {
                Debug.Log(uri + " Error: " + webRequest.error);
            }
            else
            {
                Debug.Log(uri + " Received: " + webRequest.downloadHandler.text);
                RootObject rawData = JsonUtility.FromJson<RootObject>("{\"rootData\":" + webRequest.downloadHandler.text + "}");
                foreach (var Data in rawData.rootData)
                {
                    if(Data.date_of_match!=null)
                        BackEndManager.Instance().matchDatas.Add(Data);
                }

                BackEndManager.Instance().IsMatchDataRecieved = true;
            }
        }
    }
    public override IEnumerator GetMatchesBetween(string from_date, string to_date)
    {
        BackEndManager.Instance().IsMatchDataRecieved = false;
        BackEndManager.Instance().matchDatas.Clear();
        string uri = BackEndManager.Instance().SQL_MATCH_BASE_URL + "Get?date1=" + from_date + "&date2=" + to_date;
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError)
            {
                Debug.Log(uri + " Error: " + webRequest.error);
            }
            else
            {
                Debug.Log(uri + " Received: " + webRequest.downloadHandler.text);
                RootObject rawData = JsonUtility.FromJson<RootObject>("{\"rootData\":" + webRequest.downloadHandler.text + "}");
                foreach (var Data in rawData.rootData)
                {
                    if (Data.date_of_match != null)
                        BackEndManager.Instance().matchDatas.Add(Data);
                }

                BackEndManager.Instance().IsMatchDataRecieved = true;
            }
        }
    }

    public override IEnumerator DeleteMatch(int player_id)
    {
        string uri = BackEndManager.Instance().SQL_PLAYER_BASE_URL + "Delete" + player_id.ToString();

        UnityWebRequest webRequest = new UnityWebRequest(uri, "Delete");
        yield return webRequest.SendWebRequest();

        if (webRequest.isNetworkError)
        {
            Debug.Log(uri + " Error: " + webRequest.error);
        }
        else
        {
            Debug.Log(uri + " Received: " + webRequest.downloadHandler.text);
        }
    }

    public override IEnumerator AddMatch(MatchData match)
    {
        string uri = BackEndManager.Instance().SQL_MATCH_BASE_URL + "Post";
        string jsonData = JsonUtility.ToJson(match);

        UnityWebRequest webRequest = new UnityWebRequest(uri, "Post");

        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(jsonData);
        webRequest.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        webRequest.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        webRequest.SetRequestHeader("Content-Type", "application/json");

        yield return webRequest.SendWebRequest();

        if (webRequest.isNetworkError)
        {
            Debug.Log(uri + " Error: " + webRequest.error);
        }
        else
        {
            Debug.Log(uri + " Received: " + webRequest.downloadHandler.text);
        }
    }
}