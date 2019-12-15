using UnityEngine;
using UnityEngine.UI;
public class UpadateProfileScript : MonoBehaviour
{
    public InputField usernameInput;
    public InputField firstnameInput;
    public InputField lastnameInput;
    public InputField dobInput;
    public InputField emailInput;
    public Toggle toggle;

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

    public void UpdatePlayer()
    {
        PlayerData newplayer = new PlayerData(1,
            usernameInput.ToString(),
            firstnameInput.ToString(),
            lastnameInput.ToString(),
            emailInput.ToString(),
            dobInput.ToString(),
            toggle);
        WebClient.Instance().addPlayer(newplayer);           
    }

    public void AddPlayer()
    {
        PlayerData newplayer = new PlayerData(1,
            usernameInput.ToString(),
            firstnameInput.ToString(),
            lastnameInput.ToString(),
            emailInput.ToString(),
            dobInput.ToString(),
            toggle);
        WebClient.Instance().addPlayer(newplayer);
    }
}
