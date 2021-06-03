using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public GameObject optionsMenu;
    public GameObject newGame;
    public GameObject areYouSure;
    public GameObject clearData;
    public GameObject success;
    public GameObject fontsUsed;

    public AudioMixer mixer;

    public GameObject Star1;
    public GameObject Star2;
    public GameObject Star3;

    public bool fullscreen;

    // Start is called before the first frame update.
    void Start()
    {
        Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);
        optionsMenu.SetActive(false);
        newGame.SetActive(false);
        areYouSure.SetActive(false);
        clearData.SetActive(false);
        success.SetActive(false);

        // Show if a challenge is complete.
        if (PlayerPrefs.GetInt("Complete1") == 1)
        {
            Star1.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Complete2") == 1)
        {
            Star2.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Complete3") == 1)
        {
            Star3.SetActive(true);
        }
        // Unlock the cursor so you can use it again after getting out of a playthrough.
        Cursor.lockState = CursorLockMode.None;
    }

    // Ask if you want to create a new save game.
    public void AskNewGame()
    {
        newGame.SetActive(true);
    }

    // Cancel a new game.
    public void CancelNewGame()
    {
        newGame.SetActive(false);
    }

    // Start a new save game.
    public void NewGame()
    {
        PlayerPrefs.SetInt("NormalMode", 1);
        PlayerPrefs.SetInt("Challenge", 1);
        PlayerPrefs.SetInt("LoadMe", 1);
        SceneManager.LoadScene(5);
    }

    // Takes the player to the main game.
    public void PlayGame()
    {
        PlayerPrefs.SetInt("Challenge", 1);
        if (PlayerPrefs.GetInt("NormalMode") >= 3)
        {
            PlayerPrefs.SetInt("NormalMode", 3);
        }
        PlayerPrefs.SetInt("LoadMe", 1);
        SceneManager.LoadScene(5);
    }

    // Takes the player to the Challenge mode.
    public void ChallengeMode()
    {
        PlayerPrefs.SetInt("LoadMe", 6);
        SceneManager.LoadScene(5);
    }

    // Takes the player to the custom night mode.
    public void CustomNight()
    {
        PlayerPrefs.SetInt("LoadMe", 2);
        SceneManager.LoadScene(5);
    }

    // Opens the options menu.
    public void Options()
    {
        optionsMenu.SetActive(true);
    }

    // Everything related to the volumes option.
    public void OptionsVolume(float volume)
    {
        // So the volume remains hearable until reaching mute.
        volume /= 2;
        // set the minimum to mute.
        if(volume == -40)
        {
            volume = -80;
        }
        mixer.SetFloat("vol", volume);
    }

    // Everything related to the toggle fullscreen option.
    public void optionsToggle(bool Full)
    {
        Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, Full);
        fullscreen = Full;
    }

    // Everything related to changing resolution.
    public void optionsResolution(int reso)
    {
        if(reso == 0)
        {
            Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, fullscreen);
        }
        if (reso == 1)
        {
            Screen.SetResolution(1920, 1080, fullscreen);
        }
        if (reso == 2)
        {
            Screen.SetResolution(1280, 720, fullscreen);
        }
        if (reso == 3)
        {
            Screen.SetResolution(854, 480, fullscreen);
        }
        if (reso == 4)
        {
            Screen.SetResolution(640, 360, fullscreen);
        }
    }

    // Ask if you really want to clear all save data.
    public void optionsAskClear()
    {
        clearData.SetActive(true);
    }

    // Cancel a clear data.
    public void backToOptions()
    {
        clearData.SetActive(false);
        success.SetActive(false);
    }

    // Clear all save data.
    public void optionsClearData()
    {
        PlayerPrefs.SetInt("Complete1", 0);
        PlayerPrefs.SetInt("Complete2", 0);
        PlayerPrefs.SetInt("Complete3", 0);
        PlayerPrefs.SetInt("Complete4", 0);
        PlayerPrefs.SetInt("Complete5", 0);
        PlayerPrefs.SetInt("Complete6", 0);
        Star1.SetActive(false);
        Star2.SetActive(false);
        Star3.SetActive(false);
        success.SetActive(true);
        clearData.SetActive(false);
    }

    // Return to the main menu.
    public void optionsBack()
    {
        optionsMenu.SetActive(false);
    }

    // Opens all the information about the copyright for the fonts used.
    public void FontCopyright()
    {
        fontsUsed.SetActive(true);
    }

    // Closes all the information about the copyright for the fonts used.
    public void CloseFontCopyright()
    {
        fontsUsed.SetActive(false);
    }


    // Asks if you want to quit before closing the game.
    public void QuitMenu()
    {
        areYouSure.SetActive(true);
    }
    
    // Cancel a quit.
    public void QuitBack()
    {
        areYouSure.SetActive(false);
    }

    // Quits the game.
    public void QuitGame()
    {
        Application.Quit();
    }
}
