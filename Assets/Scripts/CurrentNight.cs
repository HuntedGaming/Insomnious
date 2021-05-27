using UnityEngine;

public class CurrentNight : MonoBehaviour
{
    // Every monster + bed.
    public GameObject monster1;
    public GameObject monster2;
    public GameObject monster3;
    public GameObject monster4;
    public GameObject bed;

    // Start is called before the first frame update.
    void Start()
    {
        // Get the required components from each monster and the bed.
        Monsters mon1 = monster1.GetComponent<Monsters>();
        Monsters mon2 = monster2.GetComponent<Monsters>();
        Monsters mon3 = monster3.GetComponent<Monsters>();
        Monsters mon4 = monster4.GetComponent<Monsters>();
        Sleep slp = bed.GetComponent<Sleep>();

        // Set the difficulty of every element depending on which night it is,
        // the current night is based off of the PlayerPref NormalMode.
        switch (PlayerPrefs.GetInt("NormalMode"))
        {
            case 1:
                mon1.difficultyGrade = 1;
                mon2.difficultyGrade = 2;
                mon3.difficultyGrade = 1;
                mon4.difficultyGrade = 0;
                slp.sleepFor = 60;
                slp.deadSleepFor = 60;
                break;
            case 2:
                mon1.difficultyGrade = 2;
                mon2.difficultyGrade = 3;
                mon3.difficultyGrade = 1;
                mon4.difficultyGrade = 1;
                slp.sleepFor = 80;
                slp.deadSleepFor = 45;
                break;
            case 3:
                mon1.difficultyGrade = 3;
                mon2.difficultyGrade = 3;
                mon3.difficultyGrade = 2;
                mon4.difficultyGrade = 2;
                slp.sleepFor = 95;
                slp.deadSleepFor = 30;
                break;
        }
    }
}
