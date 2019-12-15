using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpadateProfileScript : MonoBehaviour
{
    public InputField usernameInput;
    public InputField firstnameInput;
    public InputField lastnameInput;
    public InputField dobInput;
    public InputField emailInput;

    // Start is called before the first frame update
    void Start()
    {
        usernameInput = GetComponent<InputField>();
        firstnameInput = GetComponent<InputField>();
        lastnameInput = GetComponent<InputField>();
        dobInput = GetComponent<InputField>();
        emailInput = GetComponent<InputField>();
    }

    public void CloseScreen()
    {
        ScreenManagerScript.Instance().PopScreen();
    }
}
