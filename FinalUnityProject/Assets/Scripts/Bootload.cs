using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootload : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
        ScreenManagerScript.Instance().PushScreen("GameLoadingScreen");
    }
}
