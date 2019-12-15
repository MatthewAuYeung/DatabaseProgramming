using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingScreenScript : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
	}

    public void CloseScreen()
    {
        ScreenManagerScript.Instance().PopScreen();
    }
}
