using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class CharacterMovement : MonoBehaviour
{
    public CharacterController charaControl;
    public AudioSource walk;

    public GameObject musicParent;
    public GameObject menuMusic;

    public float speed = 12f;
    public float gravity = -9.81f;

    // The audio.
    public AudioMixer mixer;

    Vector3 velocity;

    // Start is called before the first frame update.
    void Start()
    {
        musicParent = GameObject.Find("MusicParent");
        menuMusic = musicParent.transform.Find("Music").gameObject;
        menuMusic.SetActive(false);
        charaControl = GetComponent<CharacterController>();

        // Keeps the audio the same.
        mixer.SetFloat("vol", PlayerPrefs.GetFloat("Volume"));

    }

    // Update is called once per frame.
    void Update()
    {
        // Set the downwards velocity to gravity.
        velocity.y = gravity;

        // Set quick variables for forwards/backwards and left/right key presses so it is easier later.
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        // Move the player based on the inputs above.
        charaControl.Move(move * speed * Time.deltaTime);
        if (charaControl.velocity.magnitude > 2f && walk.isPlaying == false)
        {
            walk.volume = Random.Range(0.8f, 1);
            walk.pitch = Random.Range(0.8f, 1.1f);
            walk.Play();
        }

        // Pull the character around based on their velocity and time between frames.
        charaControl.Move(velocity * Time.deltaTime);

        // If the player presses escape, they are sent back to the main menu scene.
        if (Input.GetButtonDown("Cancel"))
        {
            menuMusic.SetActive(true);
            SceneManager.LoadScene(0);
        }
    }
}
