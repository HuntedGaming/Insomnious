using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public CharacterController charaControl;

    public float speed = 12f;
    public float gravity = -9.81f;

    Vector3 velocity;

    // Start is called before the first frame update.
    void Start()
    {
        charaControl = GetComponent<CharacterController>();
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

        // Pull the character around based on their velocity and time between frames.
        charaControl.Move(velocity * Time.deltaTime);
    }
}
