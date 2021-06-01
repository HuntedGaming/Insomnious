using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    public Image progressBar;

    // Start is called before the first frame update.
    void Start()
    {
        // Start async operation.
        StartCoroutine(LoadAsyncOperation());
    }

    IEnumerator LoadAsyncOperation()
    {
        // Create an async operation. Load the scene required based on the PlayerPrefs.
        AsyncOperation gameLevel = SceneManager.LoadSceneAsync(PlayerPrefs.GetInt("LoadMe"));

        while (gameLevel.progress < 1)
        {
            // Match the progress bar with the current amount loaded.
            progressBar.fillAmount = gameLevel.progress;
            yield return new WaitForEndOfFrame();
        }
    }
}
