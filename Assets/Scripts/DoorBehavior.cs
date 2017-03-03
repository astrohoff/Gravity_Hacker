using UnityEngine;

// Class for controlling doors.
public class DoorBehavior : MonoBehaviour {

    public bool isOpen = false;
    private SpriteRenderer doorRenderer;
    private BoxCollider2D doorCollider;

    private void Awake()
    {
        doorRenderer = GetComponent<SpriteRenderer>();
        doorCollider = GetComponent<BoxCollider2D>();

    }
    
    // Method that allows the doors state to be set by other scripts via a message.
    public void SetLogicState(bool state)
    {
        isOpen = state;
        UpdateLogicState();
    }

    // Update things that depend on the door's state.
    private void UpdateLogicState()
    {
        doorRenderer.enabled = !isOpen;
        doorCollider.enabled = !isOpen;
    }
}
