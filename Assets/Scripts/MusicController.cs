using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections.Generic;

public class MusicController : MonoBehaviour
{
    public string instanceName;
    public List<string> sceneNames;

    public AudioSource mainMneuMusic;

    // Start is called before the first frame update.
    void Start()
    {
        DontDestroyOnLoad(gameObject);

        // subscribe to the scene load callback.
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // delete any potential duplicates that might be in the scene already, keeping only this one .
        CheckForDuplicateInstances();

        // check if this object should be deleted based on the input scene names given.
        CheckIfSceneInList();
    }

    void CheckForDuplicateInstances()
    {
        // cache all objects containing this component.
        MusicController[] collection = FindObjectsOfType<MusicController>();

        // iterate through the objects with this component, deleting those with matching identifiers.
        foreach (MusicController obj in collection)
        {
            if (obj != this) // avoid deleting the object running this check.
            {
                if (obj.instanceName == instanceName)
                {
                    DestroyImmediate(obj.gameObject);
                }
            }
        }
    }

    void CheckIfSceneInList()
    {
        // check what scene we are in and compare it to the list of strings.
        string currentScene = SceneManager.GetActiveScene().name;

        if (sceneNames.Contains(currentScene))
        {
            // keep the object alive.
        }
        else
        {
            // unsubscribe to the scene load callback.
            SceneManager.sceneLoaded -= OnSceneLoaded;
            DestroyImmediate(gameObject);
        }
    }
}
