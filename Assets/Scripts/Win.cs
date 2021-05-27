using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
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
                }
                break;
            case 2:
                PlayerPrefs.SetInt("Complete2", 1);
                break;
            case 3:
                PlayerPrefs.SetInt("Complete3", 1);
                break;
        }
        StartCoroutine(NextNight());
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
            SceneManager.LoadScene(1);
            PlayerPrefs.SetInt("NormalMode", PlayerPrefs.GetInt("NormalMode") + 1);
        }else{
            SceneManager.LoadScene(0);
        }
    }
}
