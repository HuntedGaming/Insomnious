using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    // Start is called before the first frame update.
    void Start()
    {
        StartCoroutine(BackToMenu());
    }

    // When the game over screen shows up, wait for 5 seconds then
    // return the player to the main menu screen.
    IEnumerator BackToMenu()
    {
        yield return new WaitForSeconds(5);
        PlayerPrefs.SetInt("LoadMe", 0);
        SceneManager.LoadScene(5);
    }
}
