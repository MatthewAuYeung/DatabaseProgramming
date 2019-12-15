using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class WebClient : MonoBehaviour
{
    private static WebClient instance = null;

    public static WebClient Instance()
    {
        if (instance==null)
            instance = new WebClient();
        return instance;
    }

    private string BASE_URL = "http://localhost:50531/api/Player/";
 
   public IEnumerator getPlayerByusername(string username)
    {
        string uri = BASE_URL + "GetItems?username=" + username;
        return GetRequest(uri);
    }

   public IEnumerator addPlayer(PlayerData playerData)
    {
        string uri = BASE_URL + "PostNewPlayer";
        string jsonData = JsonUtility.ToJson(playerData);

        UnityWebRequest webRequest = new UnityWebRequest(uri, "POST");

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

   public IEnumerator updatePlayer(PlayerData PlayerData)
    {
        string uri = BASE_URL + "PutPlayer";
        string jsonData = JsonUtility.ToJson(PlayerData);

        UnityWebRequest webRequest = new UnityWebRequest(uri, "PUT");

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


    IEnumerator GetRequest(string uri)
    {
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
            }
        }
    }
}
