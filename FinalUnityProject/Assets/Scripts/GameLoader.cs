using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using UnityEngine;

public class GameLoader : MonoBehaviour
{
    private GameSystems gameSystems = null;
    private void Start()
    {
        gameSystems = new GameSystems();

        //LoadSynchronously();
        LoadAsynchronously();

    }
    private void LoadAsynchronously()
    {
        this.StartCoroutine(LoadAsyncRoutine());
    }

    private IEnumerator LoadAsyncRoutine()
    {
        Stopwatch watch = new Stopwatch();
        watch.Start();

        GameObject screenManagerPrefab = Resources.Load("ScreenManager") as GameObject;
        ScreenManagerScript screenManager = GameObject.Instantiate(screenManagerPrefab).GetComponent<ScreenManagerScript>();

        gameSystems.Register(screenManager);

        screenManager.PushScreen("LoadingScreen");

        int pendingManagers = 0;

        //AudioManager audioManager = new AudioManager();

        //gameSystems.Register(audioManager);

        //pendingManagers += 1;
        //Task.Run(() =>
        //{
        //    audioManager.Initalize();
        //}).ContinueWith((Task t)=>
        //{
        //    pendingManagers -= 1;
        //});

        //AchievementManager achievementManager = new AchievementManager();

        //gameSystems.Register(achievementManager);

        //pendingManagers += 1;
        //Task.Run(() =>
        //{
        //    achievementManager.Initialize();
        //}).ContinueWith((Task t) =>
        //{
        //    pendingManagers -= 1;
        //}); ;

        gameSystems.Register(screenManager);

        while (pendingManagers != 0)
        {
            yield return null;
        }
        watch.Stop();
        UnityEngine.Debug.Log("Loading async took " + watch.ElapsedMilliseconds + "ms");

        screenManager.PopScreen();
        screenManager.PushScreen("LandingScreen");
        yield break;
    }
    private void LoadSynchronously()
    {
        Stopwatch watch = new Stopwatch();
        watch.Start();

        AudioManager audioManager = new AudioManager();

        gameSystems.Register(audioManager);
        //audioManager.Initalize();

        AchievementManager achievementManager = new AchievementManager();

        gameSystems.Register(achievementManager);
        //achievementManager.Initialize();

        GameObject screenManagerPrefab = Resources.Load("ScreenManager") as GameObject;
        ScreenManagerScript screenManager = GameObject.Instantiate(screenManagerPrefab).GetComponent<ScreenManagerScript>();

        gameSystems.Register(screenManager);
        
        watch.Stop();
        UnityEngine.Debug.Log("Loading synchronously took "+ watch.ElapsedMilliseconds + "ms");
    }
}
