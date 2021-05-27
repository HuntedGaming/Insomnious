using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SAM : MonoBehaviour
{
    public AudioSource night1;
    public AudioSource night2;
    public AudioSource night3;

    // Start is called before the first frame update
    void Start()
    {
        // Depending on what night it is, play a certain dialogue line.
        switch(PlayerPrefs.GetInt("NormalMode"))
        {
            case (1):
                night1.Play();
                break;
            case (2):
                night2.Play();
                break;
            case (3):
                night3.Play();
                break;
        }
    }
}
