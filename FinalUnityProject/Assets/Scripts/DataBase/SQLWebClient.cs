using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SQLWebClient : WebClient
{
    public override IEnumerator GetPlayerByUsername(string username)
    {
        BackEndManager.Instance().IsRecieved = false;
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
                BackEndManager.Instance().IsRecieved = true;
            }
        }
    }

    public override IEnumerator GetPlayerByID(int id)
    {
        string uri = BackEndManager.Instance().SQL_PLAYER_BASE_URL + "Get?idplayerdata=" + id.ToString();
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
                BackEndManager.Instance().IsRecieved = true;
            }
        }
    }

    public override IEnumerator UpdatePlayerProfile(PlayerData PlayerData)
    {
        string uri = BackEndManager.Instance().SQL_PLAYER_BASE_URL + "Put";
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

    public override IEnumerable DeletePlayer(string username)
    {
        string uri = BackEndManager.Instance().SQL_PLAYER_BASE_URL + "Delete";

        UnityWebRequest webRequest = new UnityWebRequest(uri, "Delete");
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
    public override IEnumerator GetMatchesByPlayerID(int player_id)
    {
        BackEndManager.Instance().IsRecieved = false;
        string uri = BackEndManager.Instance().SQL_MATCH_BASE_URL + "Get?idplayerdata=" + player_id.ToString();
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
                BackEndManager.Instance().IsRecieved = true;
            }
        }
    }
    public override IEnumerator GetMatchesBetween(string from_date, string to_date)
    {
        BackEndManager.Instance().IsRecieved = false;
        string uri = BackEndManager.Instance().SQL_MATCH_BASE_URL + "Get?date_of_match=" + from_date + "&date_of_match" + to_date;
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
                BackEndManager.Instance().matchDatas.Add(JsonUtility.FromJson<MatchData>(webRequest.downloadHandler.text));
                BackEndManager.Instance().IsRecieved = true;
            }
        }
    }

    public override IEnumerable DeleteMatch(int player_id)
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

