using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidFunctions : MonoBehaviour
{


    public void ShowStaticHelloWorldLog()
    {
        // Get java class from my plugin
        AndroidJavaClass androidLibraryUtility =
            new AndroidJavaClass("com.mattheway.tools.Utility");

        // Call static function
        androidLibraryUtility.CallStatic("HelloWorld");
    }

    public void ShowToastMessage(string message)
    {
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");

        AndroidJavaObject unityActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

        AndroidJavaObject applicationContext = unityActivity.Call<AndroidJavaObject>("getApplicationContext");

        AndroidJavaClass androidLibraryUtility = new AndroidJavaClass("com.mattheway.tools.Utility");

        AndroidJavaObject utilityPlugin =
    androidLibraryUtility.CallStatic<AndroidJavaObject>("Create", unityActivity, applicationContext);


        utilityPlugin.Call("ShowToastMessage", message);
    }

    public int notificationTime = 1;

    public void ShowNotification(string message)
    {
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        //Grab the activity from the class via static function
        AndroidJavaObject unityActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

        AndroidJavaObject applicationContext = unityActivity.Call<AndroidJavaObject>("getApplicationContext");

        AndroidJavaClass utilityClass = new AndroidJavaClass("com.mattheway.tools.Utility");
        AndroidJavaObject utilityInstance = utilityClass.CallStatic<AndroidJavaObject>("Create", unityActivity, applicationContext);
        utilityInstance.Call("ShowNotification", message, notificationTime);

    }
}