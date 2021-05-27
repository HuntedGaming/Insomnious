using UnityEngine;
using UnityEngine.EventSystems;

public class Star : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject textBox;

    // Detect if the Cursor starts to pass over the GameObject.
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        // Display the textbox when the cursor passes over the GameObject.
        textBox.SetActive(true);
    }

    // Detect when Cursor leaves the GameObject.
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        // Hide the textbox when the cursor leaves the GameObject.
        textBox.SetActive(false);
    }
}
