using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using TMPro;

public class Monsters : MonoBehaviour
{
    // Everything related to the Monster.
    public GameObject monsterModel;
    public GameObject jumpscareAnimation;
    public Animator monsterAnimation;
    public AudioSource transition1;
    public AudioSource transition2;
    public AudioSource transition3;
    public AudioSource JumpScare;
    public float monsterAttackTimer;
    public int monsterAggression;
    int monsterStageCounter;
    int monsterAttackCounter;
    float monsterWaitTimer;
    public bool sleepAttack;
    public TMP_Text hintText;

    // Everything related to the difficulty.
    public int difficultyGrade;
    int attackDifficult;
    float stopAttackTimer;

    // Related to dying.
    public GameObject[] otherMons;
    public GameObject sleepBar;

    public Image timerWheel;

    // Start is called before the first frame update.
    void Start()
    {
        // Sets everything for monster to the least active state.
        monsterWaitTimer = monsterAttackTimer;
        sleepAttack = false;
        jumpscareAnimation.SetActive(false);
        sleepBar.SetActive(true);

        // Depending on the difficultyGrade, set the attackDifficult
        // to different numbers to make the monsters attack more or
        // less often.
        switch (difficultyGrade)
        {
            case (1):
                attackDifficult = 10;
                break;
            case (2):
                attackDifficult = 25;
                break;
            case (3):
                attackDifficult = 50;
                break;
            case (4):
                attackDifficult = 100;
                break;
            case (5):
                attackDifficult = 200;
                break;
        }

        //Set the stop attack timer and the UI to it's default value.
        stopAttackTimer = 0f;
        timerWheel.gameObject.SetActive(false);
    }

    // Update is called once per frame.
    void Update()
    {
        // Count down the monster timer.
        monsterWaitTimer -= Time.deltaTime;
        // When the monster timer reaches 0, reset the counter back
        // to 18 and pick a random number between 1 and 100. If that number
        // is less than current difficulty, increase attack stage.
        if (monsterWaitTimer <= 0)
        {
            monsterWaitTimer = monsterAttackTimer;
            monsterAttackCounter = Random.Range(1, monsterAggression);
            if(monsterAttackCounter <= attackDifficult)
            {
                monsterStageCounter++;
            }
        }
        bool tran1Done = false;
        bool tran2Done = false;
        bool tran3Done = false;
        // Depending on which stage the mosnter is in, have
        // the animator play certain animations. If the
        // monster reaches stage 4, the player dies.
        switch (monsterStageCounter)
        {
            case (1):
                monsterAnimation.SetInteger("MonsterStage", 1);
                if (!tran1Done)
                {
                    transition1.volume = Random.Range(0.8f, 1);
                    transition1.pitch = Random.Range(0.8f, 1.1f);
                    transition1.Play();
                    tran1Done = true;
                }
                tran2Done = false;
                break;
            case (2):
                monsterAnimation.SetInteger("MonsterStage", 2);
                if (!tran2Done)
                {
                    transition2.volume = Random.Range(0.8f, 1);
                    transition2.pitch = Random.Range(0.8f, 1.1f);
                    transition2.Play();
                    tran2Done = true;
                }
                tran1Done = false;
                tran3Done = false;
                break;
            case (3):
                monsterAnimation.SetInteger("MonsterStage", 3);
                sleepAttack = false;
                if (!tran3Done)
                {
                    transition3.volume = Random.Range(0.8f, 1);
                    transition3.pitch = Random.Range(0.8f, 1.1f);
                    transition3.Play();
                    tran3Done = true;
                }
                tran2Done = false;
                break;
            case (4):
                monsterAnimation.SetInteger("MonsterStage", 4);
                sleepAttack = true;
                break;
            case (5):
                sleepBar.SetActive(false);
                hintText.text = "";
                jumpscareAnimation.SetActive(true);
                JumpScare.Play();
                jumpscareAnimation.GetComponent<VideoPlayer>().loopPointReached += CheckOver;
                break;
        }
    }

    // When the jumpscare finishes, load the game over scene.
    void CheckOver(VideoPlayer vp)
    {
        SceneManager.LoadScene(3);
    }


    void OnTriggerEnter(Collider other)
    {
        // When the player enters the trigger, set the stop attack timer to 0.
        stopAttackTimer = 0f;
    }

    void OnTriggerStay(Collider other)
    {
        // If the monster is more active then stage 1, and the player is
        // holding down the space bar, star reversing the monster's progress.
        if (other.gameObject.tag == "Player" && monsterStageCounter > 1 && Input.GetKey("space"))
        {
            stopAttackTimer += Time.deltaTime;
            timerWheel.gameObject.SetActive(true);
            timerWheel.fillAmount = stopAttackTimer / 2;
            if (stopAttackTimer >= 2)
            {
                monsterStageCounter--;
                stopAttackTimer = 0f;
                timerWheel.gameObject.SetActive(false);
            }
        }
        else if (Input.GetKeyUp("space"))
        {
            stopAttackTimer = 0f;
            timerWheel.gameObject.SetActive(false);
        }

        // If the moster is active, show the hint.
        if (monsterStageCounter > 1)
        {
            hintText.text = "Hold SPACE to suppress";
        }
    }

    void OnTriggerExit(Collider other)
    {
        // When the player leaves the trigger, hide the text.
        hintText.text = "";
    }
}
