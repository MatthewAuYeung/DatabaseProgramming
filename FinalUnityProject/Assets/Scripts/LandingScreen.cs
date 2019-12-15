using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LandingScreen : MonoBehaviour
{
    public InputField username;

    [SerializeField]
    private Button startGameButton;
    [SerializeField]
    private Button settingButton;
    [SerializeField]
    private Button contactusButton;
    [SerializeField]
    private Button achivementButton;
    [SerializeField]
    private Button updateprofileButton;

    private bool _login = false;
    private void Awake()
    {
        username = GetComponent<InputField>();
    }

    private void Start()
    {
        startGameButton.onClick.AddListener(StartButtonClickdCallback);
        settingButton.onClick.AddListener(SettingButtonClickedCallback);
        contactusButton.onClick.AddListener(ContactUsButtonClickedCallback);
        achivementButton.onClick.AddListener(AchivementButtonClickedCallback);
        updateprofileButton.onClick.AddListener(UpdateProfileButtonClickedCallback);
    }

    private void SettingButtonClickedCallback()
    {
        ScreenManagerScript.Instance().PushScreen("SettingScreen");
    }

    private void ContactUsButtonClickedCallback()
    {
        ScreenManagerScript.Instance().PushScreen("ContactUsScreen");
    }

    private void AchivementButtonClickedCallback()
    {
        ScreenManagerScript.Instance().PushScreen("AchivementScreen");
    }

    private void UpdateProfileButtonClickedCallback()
    {
        ScreenManagerScript.Instance().PushScreen("UpdateProfileScreen");
    }

    private void OnDestroy()
    {
        startGameButton.onClick.RemoveListener(StartButtonClickdCallback);
    }

    private void StartButtonClickdCallback()
    {
        if(_login)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Login()
    {
        _login = true;
    }
}
