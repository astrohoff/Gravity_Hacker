using UnityEngine;
using System.Collections.Generic;
using System.Collections;

// Class for controlling a button object.
public class ButtonBehavior : MonoBehaviour
{
    // List of GameObjects that the button controls.
    public GameObject typeIndicator;
    // Colors that indicate the button's state.
    public Color unpressedColor = new Color(0.5f, 0, 0);
    public Color pressedColor = new Color(1, 0, 0);
    // Renderer on the button's knob, needed to change the color.
    public SpriteRenderer buttonKnobRenderer;
	public bool stayActive = false;

    // List of objects currently touching the button.
    private List<GameObject> pressingObjects;
    private LogicManager logicManager;

    // On script instantiation...
    private void Awake()
    {
        // Initialize variables.
        pressingObjects = new List<GameObject>();
        logicManager = GetComponent<LogicManager>();
		if (!stayActive) {
			typeIndicator.SetActive (false);
		}
    }

    // Before 1st frame...
    private void Start()
    {
        // Perform initial logic state update.
        logicManager.SetState(CheckIsPressed());
        UpdateButtonState();
    }

    // Every frame...
    private void Update()
    {
        // Check if the button's pressed state has changed, and update the
        // logic state if it has.
		bool pressState = CheckIsPressed() || (stayActive && logicManager.state);
        if (pressState != logicManager.GetState())
        {
            logicManager.SetState(pressState);
            UpdateButtonState();
        }
    }

    // Update things controlled by the button's logic state.
    private void UpdateButtonState()
    {
        bool isActive = logicManager.GetState();
        // Set button color.
        if (isActive)
            buttonKnobRenderer.color = pressedColor;
        else
            buttonKnobRenderer.color = unpressedColor;
    }

    // Checks the button's press state.
    // This will probably become more complex as more features are added.
    private bool CheckIsPressed()
    {
        return pressingObjects.Count > 0;
    }

    // Add a new pressing object to the list.
    // Called by ButtonPressDetector when a GameObject starts touching
    // the button knob.
    public void AddPressingObject(GameObject obj)
    {
        pressingObjects.Add(obj);
    }

    // Remove a pressing object from the list.
    // Called by ButtonPressDetector when a GameObject stops touching
    // the button knob.
    public void RemovePressingObject(GameObject obj)
    {
        pressingObjects.Remove(obj);
    }
}