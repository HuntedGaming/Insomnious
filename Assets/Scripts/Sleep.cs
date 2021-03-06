using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using Steamworks;
using TMPro;

public class Sleep : MonoBehaviour
{
    // Everything related to sleep timers.
    float sleepTimer;
    public float sleepFor;
    float deadSleepTimer;
    public float deadSleepFor;
    int timesSlept;

    // Everything related to UI.
    public Image sleepBar;
    public GameObject nightmareJumpscare;
    public GameObject sleepBack;
    public TMP_Text hintText;

    // Everything related to monsters.
    public bool isAsleep;
    public GameObject[] monsters;

    public GameObject player;

    // Start is called before the first frame update.
    void Start()
    {
        // Sets everything to default values.
        sleepTimer = 0f;
        deadSleepTimer = 0f;
        isAsleep = false;
        sleepBar.fillAmount = 0f;
        timesSlept = 0;
    }

    // Update is called once per frame.
    void Update()
    {
        // For each monster in the array, check if they have the Monsters script
        // then compare if the sleepAttack bool is true and if the character is
        // asleep, if both are true then the character dies.
        foreach (var mons in monsters)
        {
            if (mons.GetComponent<Monsters>())
            {
                Monsters slpAtk = mons.GetComponent<Monsters>();
                if (slpAtk.sleepAttack == true && isAsleep == true)
                {
                    nightmareJumpscare.SetActive(false);
                    sleepBack.SetActive(false);
                    hintText.text = "";
                    slpAtk.jumpscareAnimation.SetActive(true);
                    slpAtk.jumpscareAnimation.GetComponent<VideoPlayer>().loopPointReached += CheckOver;
                }

                // if deadSleepTimer reaches a number equal to or higher than deadSleepFor,
                // the character dies.
                if (deadSleepTimer >= deadSleepFor)
                {
                    SceneManager.LoadScene(3);
                    
                }

                // If the player successfully gets the sleepTimer to sleepFor, they win.
                if (sleepTimer >= sleepFor)
                {
                    if (!SteamManager.Initialized) { return; }
                    SteamUserStats.SetAchievement("Miscellaneous1");
                    SteamUserStats.StoreStats();
                    SceneManager.LoadScene(4);
                }
            }
        }

        // if isAsleep is true, start counting up with the sleep and deadSleep
        // timers, also fill the sleep bar so that it shows the player their progress.
        // When asleep the player cannot move.
        if (isAsleep == true)
        {
            hintText.text = "Press E to wake up";
            // Everything related to sleep timers and progress.
            sleepTimer += Time.deltaTime;
            deadSleepTimer += Time.deltaTime;
            sleepBar.fillAmount = sleepTimer / sleepFor;
            
            // Everything related to the player.
            player.GetComponent<CharacterMovement>().speed = 0;
            player.GetComponent<MouseLook>().enabled = false;

            // Everything related to the nightmare.
            nightmareJumpscare.SetActive(true);
            sleepBack.SetActive(true);
            nightmareJumpscare.GetComponent<VideoPlayer>().playbackSpeed = 1 / deadSleepFor;
        }
        else
        {
            // Everything related to the player.
            player.GetComponent<CharacterMovement>().speed = 12;
            player.GetComponent<MouseLook>().enabled = true;

            // Everything related to the nightmare.
            nightmareJumpscare.SetActive(false);
            sleepBack.SetActive(false);
            var nightmareVideo = nightmareJumpscare.GetComponent<VideoPlayer>();
            nightmareVideo.frame = 0;
        }
    }

    void CheckOver(VideoPlayer vp)
    {
        SceneManager.LoadScene(3);
    }

    void OnTriggerEnter(Collider other)
    {
        // When the player enters the trigger, set the dead sleep timer to 0.
        deadSleepTimer = 0f;
    }

    void OnTriggerStay(Collider other)
    {
        hintText.text = "Press SPACE to sleep";
        // When the player is in the trigger and presses the space bar, set
        // isAsleep to true.
        if (other.gameObject.tag == "Player" && Input.GetKey("space"))
        {
            isAsleep = true;
            timesSlept++;
        }
        if (Input.GetKey("e") && isAsleep == true)
        {
            hintText.text = "";
            deadSleepTimer = 0f;
            isAsleep = false;
        }
    }
    
    // Hide the Hint after leaving the trigger area.
    void OnTriggerExit(Collider other)
    {
        hintText.text = "";
    }
}
