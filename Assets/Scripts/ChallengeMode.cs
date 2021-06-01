using UnityEngine.SceneManagement;
using UnityEngine;

public class ChallengeMode : MonoBehaviour
{
    // Menu view and Game Starter.
    public GameObject cam1;
    public GameObject selector;
    public GameObject challengeStarter;

    // Every monster + bed.
    public GameObject monster1;
    public GameObject monster2;
    public GameObject monster3;
    public GameObject monster4;
    public GameObject bed;

    // Each challenge.
    public GameObject challenge1;
    public GameObject challenge2;
    public GameObject challenge3;

    // Each star.
    public GameObject Star1;
    public GameObject Star2;
    public GameObject Star3;

    // Start is called before the first frame update.
    void Start()
    {
        // Set all values to default
        cam1.SetActive(true);
        selector.SetActive(true);
        challengeStarter.SetActive(false);
        challenge1.SetActive(true);
        challenge2.SetActive(false);
        challenge3.SetActive(false);
        Star1.SetActive(false);
        Star2.SetActive(false);
        Star3.SetActive(false);

        Challenge1();

        // Set the stars to active if the challenge has been completed.
        if (PlayerPrefs.GetInt("Complete4") == 1)
        {
            Star1.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Complete5") == 1)
        {
            Star2.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Complete6") == 1)
        {
            Star3.SetActive(true);
        }
    }

    // Goes back to the main menu.
    public void MainMenu()
    {
        PlayerPrefs.SetInt("LoadMe", 0);
        SceneManager.LoadScene(5);
    }

    // Starts the challenge.
    public void StartChallenge()
    {
        cam1.SetActive(false);
        selector.SetActive(false);
        challengeStarter.SetActive(true);
    }

    // sets everything to challenge 1.
    public void Challenge1()
    {
        challenge1.SetActive(true);
        challenge2.SetActive(false);
        challenge3.SetActive(false);

        // Sets the monster difficulty for each monster.
        Monsters mon1 = monster1.GetComponent<Monsters>();
        mon1.difficultyGrade = 4;
        Monsters mon2 = monster2.GetComponent<Monsters>();
        mon2.difficultyGrade = 3;
        Monsters mon3 = monster3.GetComponent<Monsters>();
        mon3.difficultyGrade = 2;
        Monsters mon4 = monster4.GetComponent<Monsters>();
        mon4.difficultyGrade = 0;

        // Sets the sleep timer and dead sleep timer for the bed.
        Sleep slp = bed.GetComponent<Sleep>();
        slp.sleepFor = 60;
        slp.deadSleepFor = 45;

        PlayerPrefs.SetInt("Challenge", 4);
    }

    // sets everything to challenge 2.
    public void Challenge2()
    {
        challenge1.SetActive(false);
        challenge2.SetActive(true);
        challenge3.SetActive(false);

        // Sets the monster difficulty for each monster.
        Monsters mon1 = monster1.GetComponent<Monsters>();
        mon1.difficultyGrade = 0;
        Monsters mon2 = monster2.GetComponent<Monsters>();
        mon2.difficultyGrade = 0;
        Monsters mon3 = monster3.GetComponent<Monsters>();
        mon3.difficultyGrade = 0;
        Monsters mon4 = monster4.GetComponent<Monsters>();
        mon4.difficultyGrade = 5;

        // Sets the sleep timer and dead sleep timer for the bed.
        Sleep slp = bed.GetComponent<Sleep>();
        slp.sleepFor = 40;
        slp.deadSleepFor = 15;

        PlayerPrefs.SetInt("Challenge", 5);
    }

    // sets everything to challenge 3.
    public void Challenge3()
    {
        challenge1.SetActive(false);
        challenge2.SetActive(false);
        challenge3.SetActive(true);

        // Sets the monster difficulty for each monster.
        Monsters mon1 = monster1.GetComponent<Monsters>();
        mon1.difficultyGrade = 2;
        Monsters mon2 = monster2.GetComponent<Monsters>();
        mon2.difficultyGrade = 4;
        Monsters mon3 = monster3.GetComponent<Monsters>();
        mon3.difficultyGrade = 1;
        Monsters mon4 = monster4.GetComponent<Monsters>();
        mon4.difficultyGrade = 1;

        // Sets the sleep timer and dead sleep timer for the bed.
        Sleep slp = bed.GetComponent<Sleep>();
        slp.sleepFor = 60;
        slp.deadSleepFor = 20;

        PlayerPrefs.SetInt("Challenge", 6);
    }
}
