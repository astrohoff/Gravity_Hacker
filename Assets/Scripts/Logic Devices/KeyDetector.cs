using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class for detecting if the player has a key.
public class KeyDetector : MonoBehaviour {
    private GameObject player;
    // Player's KeyManager component.
    private KeyManager keyManager;
    // Key detector's logic manager.
    private LogicManager logicManager;
    // If true, KeyManager will be checked for a key with the below requieredKeyID value.
    // If false, the KeyManager will be checked for any key.
    public bool checkKeyId = false;
    public int requiredKeyId = 0; 

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        keyManager = player.GetComponent<KeyManager>();
        logicManager = GetComponent<LogicManager>();
    }

    private void OnTriggerStay2D(Collider2D c)
    {
        // If a key has not already been detected...
        if (!logicManager.GetState())
        {
            // If the player has entered the detection zone...
            if(c.tag == "Player")
            {
                CheckForKey();               
            }
        }
    }

    private void CheckForKey()
    {
        // Use appropriate KeyManager methods for whether the key ID should be checked (checkKeyId).
        if (checkKeyId)
        {
            if (keyManager.CheckHasKey(requiredKeyId))
            {
                keyManager.RemoveKey(requiredKeyId);
                logicManager.SetState(true);
            }
        }
        else
        {
            if (keyManager.CheckHasKey())
            {
                keyManager.RemoveKey();
                logicManager.SetState(true);
            }
        }
    }
}
