using System.Collections;
using Steamworks;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public AudioMixer mixer;
    
    // Start is called before the first frame update.
    void Start()
    {
        // Check which challenge is currently active.
        switch (PlayerPrefs.GetInt("Challenge"))
        {
            case 1:
                if (PlayerPrefs.GetInt("NormalMode") == 3)
                {
                    PlayerPrefs.SetInt("Complete1", 1);
                    if (!SteamManager.Initialized) { return; }
                    SteamUserStats.SetAchievement("Main3");
                    SteamUserStats.StoreStats();
                }
                break;
            case 2:
                PlayerPrefs.SetInt("Complete2", 1);
                if (!SteamManager.Initialized) { return; }
                SteamUserStats.SetAchievement("Custom1");
                SteamUserStats.StoreStats();
                break;
            case 3:
                PlayerPrefs.SetInt("Complete3", 1);
                if (!SteamManager.Initialized) { return; }
                SteamUserStats.SetAchievement("Custom2");
                SteamUserStats.StoreStats();
                break;
            case 4:
                PlayerPrefs.SetInt("Complete4", 1);
                if (!SteamManager.Initialized) { return; }
                SteamUserStats.SetAchievement("Challenge1");
                SteamUserStats.StoreStats();
                break;
            case 5:
                PlayerPrefs.SetInt("Complete5", 1);
                if (!SteamManager.Initialized) { return; }
                SteamUserStats.SetAchievement("Challenge2");
                SteamUserStats.StoreStats();
                break;
            case 6:
                PlayerPrefs.SetInt("Complete6", 1);
                if (!SteamManager.Initialized) { return; }
                SteamUserStats.SetAchievement("Challenge3");
                SteamUserStats.StoreStats();
                break;
        }
        StartCoroutine(NextNight());

        mixer.GetFloat("vol", out float volume);
        if (volume == -80f)
        {
            if (!SteamManager.Initialized) { return; }
            SteamUserStats.SetAchievement("Miscellaneous2");
            SteamUserStats.StoreStats();
        }
    }

    // When the win screen shows up, wait for 5 seconds then
    // return the player to the main menu screen if they were
    // playing the custom night mode, if playing the normal game
    // continue on to the next night.
    IEnumerator NextNight()
    {
        yield return new WaitForSeconds(5);
        if (PlayerPrefs.GetInt("Challenge") == 1 && PlayerPrefs.GetInt("NormalMode") < 3)
        {
            PlayerPrefs.SetInt("LoadMe", 1);
            SceneManager.LoadScene(5);
            PlayerPrefs.SetInt("NormalMode", PlayerPrefs.GetInt("NormalMode") + 1);
        }else{
            PlayerPrefs.SetInt("LoadMe", 0);
            SceneManager.LoadScene(5);
        }
    }
}
