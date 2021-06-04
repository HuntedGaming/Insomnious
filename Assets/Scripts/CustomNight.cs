using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class CustomNight : MonoBehaviour
{
    // Menu view and Game Starter.
    public GameObject cam1;
    public GameObject editor;
    public GameObject customStarter;
    public GameObject menuMusic;

    // Every monster + bed.
    public GameObject monster1;
    public GameObject monster2;
    public GameObject monster3;
    public GameObject monster4;
    public GameObject bed;

    // The text below the sliders.
    public TMP_Text monText1;
    public TMP_Text monText2;
    public TMP_Text monText3;
    public TMP_Text monText4;
    public TMP_Text sleepForText;
    public TMP_Text deadSleepForText;

    // Start is called before the first frame update.
    void Start()
    {
        cam1.SetActive(true);
        editor.SetActive(true);
        customStarter.SetActive(false);
        menuMusic = GameObject.Find("Music");
        monText1.text = "1";
        monText2.text = "1";
        monText3.text = "1";
        monText4.text = "1";
        sleepForText.text = "20";
        deadSleepForText.text = "5";

        PlayerPrefs.SetInt("Challenge", 2);
    }

    // Difficulty rating for Monster 1.
    public void Monster1Difficulty(float difficult)
    {
        int dif = Mathf.RoundToInt(difficult);
        Monsters mon1 = monster1.GetComponent<Monsters>();
        mon1.difficultyGrade = dif;
        monText1.text = difficult.ToString();
    }

    // Difficulty rating for Monster 2.
    public void Monster2Difficulty(float difficult)
    {
        int dif = Mathf.RoundToInt(difficult);
        Monsters mon2 = monster2.GetComponent<Monsters>();
        mon2.difficultyGrade = dif;
        monText2.text = difficult.ToString();
    }

    // Difficulty rating for Monster 3.
    public void Monster3Difficulty(float difficult)
    {
        int dif = Mathf.RoundToInt(difficult);
        Monsters mon3 = monster3.GetComponent<Monsters>();
        mon3.difficultyGrade = dif;
        monText3.text = difficult.ToString();
    }

    // Difficulty rating for Monster 4.
    public void Monster4Difficulty(float difficult)
    {
        int dif = Mathf.RoundToInt(difficult);
        Monsters mon4 = monster4.GetComponent<Monsters>();
        mon4.difficultyGrade = dif;
        monText4.text = difficult.ToString();
    }

    // How long do you need to sleep to win.
    public void SleepFor(float timer)
    {
        Sleep slp = bed.GetComponent<Sleep>();
        slp.sleepFor = timer;
        sleepForText.text = timer.ToString();
    }

    // How long can you sleep before dying in your sleep.
    public void DeadSleepFor(float timer)
    {
        Sleep slp = bed.GetComponent<Sleep>();
        slp.deadSleepFor = timer;
        deadSleepForText.text = timer.ToString();
    }

    // Button to return to main menu.
    public void BackButton()
    {
        SceneManager.LoadScene(0);
    }

    // Button to start the game.
    public void StartGame()
    {
        menuMusic.SetActive(false);
        if (Convert.ToInt32(monText1) == 5 && Convert.ToInt32(monText2) == 5 && Convert.ToInt32(monText3) == 5 && Convert.ToInt32(monText4) == 5 && Convert.ToInt32(sleepForText) == 120 && Convert.ToInt32(deadSleepForText) == 5)
        {
            PlayerPrefs.SetInt("Challenge", 3);
        }
        cam1.SetActive(false);
        editor.SetActive(false);
        customStarter.SetActive(true);
    }
}
