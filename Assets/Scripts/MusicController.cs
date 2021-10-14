using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections.Generic;

public class MusicController : MonoBehaviour
{
    public string instanceName;

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
}
