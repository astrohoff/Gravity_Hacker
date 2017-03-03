using UnityEngine;
using System.Collections.Generic;

// Class for controlling a button object.
public class ButtonBehavior : MonoBehaviour
{
    // List of objects currently touching the button.
    private List<GameObject> pressingObjects;
    // List of GameObjects that the button controls.
    public GameObject[] connectedDevices;
    private bool isActivated = false;
    // Colors that indicate the button's state.
    public Color unpressedColor = new Color(0.5f, 0, 0);
    public Color pressedColor = new Color(1, 0, 0);
    // Renderer on the button's knob, needed to change the color.
    public SpriteRenderer buttonKnobRenderer;

    // On script instantiation...
    private void Awake()
    {
        // Initialize variables.
        pressingObjects = new List<GameObject>();
    }

    // Before 1st frame...
    private void Start()
    {
        // Perform initial logic state update.
        UpdateLogicState(CheckIsPressed());
    }

    // Every frame...
    private void Update()
    {
        // Check if the button's pressed state has changed, and update the
        // logic state if it has.
        bool pressState = CheckIsPressed();
        if (pressState != isActivated)
        {
            UpdateLogicState(pressState);
        }
    }

    // Update things controlled by the button's logic state.
    private void UpdateLogicState(bool pressState)
    {
        isActivated = pressState ;
        // Set button color.
        if (isActivated)
            buttonKnobRenderer.color = pressedColor;
        else
            buttonKnobRenderer.color = unpressedColor;
        // Set logic state of connected devices.
        for(int i = 0; i < connectedDevices.Length; i++)
        {
            connectedDevices[i].SendMessage("SetLogicState", isActivated);
        }
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