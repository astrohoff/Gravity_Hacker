using UnityEngine;

// Class for controlling doors.
public class DoorBehavior : MonoBehaviour {
    private SpriteRenderer doorRenderer;
    private BoxCollider2D doorCollider;
    private LogicManager logicManager;

    private void Awake()
    {
        doorRenderer = GetComponent<SpriteRenderer>();
        doorCollider = GetComponent<BoxCollider2D>();
        logicManager = GetComponent<LogicManager>();

    }

    // Update things that depend on the door's state.
    public void UpdateLogicState()
    {
        bool isOpen = logicManager.GetState();
        doorRenderer.enabled = !isOpen;
        doorCollider.enabled = !isOpen;
    }
}
