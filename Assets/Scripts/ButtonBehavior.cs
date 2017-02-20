using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attatch to push part of button.
public class ButtonBehavior : MonoBehaviour {
    /*// How quickly the button moves up and down.
    public float pressSpeed = 1f;
    // Is the button fully pressed?
    public bool isPressed;
    // Anchor transforms for pressed and unpressed positions.
    public Transform pressedAnchor, unpressedAnchor, pushPart;

    // 0 = fully unpressed, 1 = fully pressed.
    private float pressedAmount = 0;
    private List<GameObject> pressingObjects;

	// Use this for initialization
	void Start () {
        pressingObjects = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
		if(pressedAmount < 1)
        {
            if (pressingObjects.Count > 0)
            {
                pressedAmount += Time.deltaTime * pressSpeed;
                Mathf.Clamp01(pressedAmount);
                isPressed = pressedAmount == 1;
            }
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (CheckCanPress(collision.gameObject))
        {
            pressingObjects.Add(gameObject);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        pressingObjects.Remove(collision.gameObject);
    }

    private void OnCollisionStay(Collision collision)
    {
        string collidingObjectTag = collision.gameObject.tag;
        if (collidingObjectTag == "Box" || collidingObjectTag == "Player")
        {
            if (pressedAmount < 1)
            {
                pressedAmount = Mathf.Clamp01(pressedAmount + Time.deltaTime * pressSpeed);
                pushPart.transform.position = Vector2.Lerp(unpressedAnchor.position, pressedAnchor.position, pressedAmount);
                isPressed = pressedAmount == 1;
            }
        }
        else if (pressedAmount > 0)
        {
            pressedAmount = Mathf.Clamp01(pressedAmount - Time.deltaTime * pressSpeed);
            pushPart.transform.position = Vector2.Lerp(unpressedAnchor.position, pressedAnchor.position, pressedAmount);
            isPressed = false;
        }
    }

    private bool CheckCanPress(GameObject obj)
    {
        bool canPress = obj.tag == "Player";
        canPress =  canPress || obj.tag == "Box";
        return canPress;
    }*/
    public bool isPressed;
    public float pressSpeed;
    public Transform pressPart, unpressedAnchor, pressedAnchor;
    private List<GameObject> pressingObjects;
    private float pressedAmount = 0;

    private void Update()
    {
        // If there are objects on the button and it is not fully pressed
        // move the button down
        // Else if there are not objects on the button and it not fully unpressed
        // move the button up

        bool pressUpdated = false;
        if(pressingObjects.Count > 0 && pressedAmount < 1)
        {
            pressedAmount += Time.deltaTime * pressSpeed;
        }
        else if(pressingObjects.Count == 0 && pressedAmount > 0)
        {
            pressedAmount -= Time.deltaTime * pressSpeed;
        }
        if (pressUpdated)
        {
            Mathf.Clamp01(pressedAmount);
            pressPart.position = Vector2.Lerp(unpressedAnchor.position, pressedAnchor.position, pressedAmount);
            isPressed = pressedAmount == 1;
        }
    }
}
