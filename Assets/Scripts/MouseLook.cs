using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivty = 100f;

    public Transform playerBody;
    public Transform camHead;

    float xRotation = 0f;
    float yRotation = 0f;

    // Start is called before the first frame update.
    void Start()
    {
        // Locks the cursor so that it does not accidently click off the game.
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame.
    void Update()
    {
        // Making variables for looking up/down and left/right according to mouse sensitivity and time between frames.
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivty * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivty * Time.deltaTime;

        // Setting up how far to rotate the camera and stopping it at a certain point.
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        yRotation += mouseX;

        // Rotating the camera.
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);



    }
}
