using UnityEngine;
using UnityEngine.UI;
public class UpadateProfileScript : MonoBehaviour
{
    private SQLWebClient sqlWebClient = new SQLWebClient();
    public InputField usernameInput;
    public InputField firstnameInput;
    public InputField lastnameInput;
    public InputField dobInput;
    public InputField emailInput;
    public Toggle toggle;

    // Start is called before the first frame update


    public void CloseScreen()
    {
        ScreenManagerScript.Instance().PopScreen();
    }

    public void UpdatePlayer()
    {
        PlayerData newplayer = new PlayerData();
        newplayer.FillProfile(
            usernameInput.text,
            firstnameInput.text,
            lastnameInput.text,
            emailInput.text,
            dobInput.text,
            toggle);
        newplayer.idplayerdata = GameLoader.playerID;
        StartCoroutine(sqlWebClient.UpdatePlayerProfile(newplayer));           
    }

    public void AddPlayer()
    {
        PlayerData newplayer = new PlayerData();
        newplayer.FillProfile(
            usernameInput.text,
            firstnameInput.text,
            lastnameInput.text,
            emailInput.text,
            dobInput.text,
            toggle);
        StartCoroutine(sqlWebClient.AddPlayer(newplayer));
    }
}
