using UnityEngine;
using System;

// Class for detecting objects pressing the button, and relaying
// that info to the button behavior.
// This is needed because the ButtonBehavior script goes on the root
// button GameObject, but only objects touching the knob part of the
// button should affect its press. 
public class ButtonPressDetector : MonoBehaviour {
	private string[] unpressableTags = new string[]{"Bullet", "Key"};
    // ButtonBehavior to send updates to.
    public ButtonBehavior buttonBehavior;

	private void OnCollisionEnter2D(Collision2D c)
    {
		// Don't let bullets press buttons.
		if (Array.IndexOf(unpressableTags, c.gameObject.tag) == -1) {			
			// Let the ButtonBehavior know a new object is pressing.
			buttonBehavior.AddPressingObject (c.gameObject);
		}
    }

    private void OnCollisionExit2D(Collision2D c)
    {
        // Let the ButtonBehavior know that a object has stopped pressing.
        buttonBehavior.RemovePressingObject(c.gameObject);
    }
}
