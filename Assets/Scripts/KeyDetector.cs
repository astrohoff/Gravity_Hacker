using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDetector : MonoBehaviour {
    private GameObject player;
    private KeyManager keyManager;
    private LogicManager logicManager;
    public float senseDistance = 2f;
    public bool checkKeyId = false;
    public int requiredKeyId = 0; 

    private void Awake()
    {
        player = GameObject.Find("Player");
        keyManager = player.GetComponent<KeyManager>();
        logicManager = GetComponent<LogicManager>();
    }
	
	// Update is called once per frame
	void Update () {
        // Check for a key if detector hasn't found anything yet.
        if (!logicManager.GetState())
        {
            // Check if player is close enough.
            if ((player.transform.position - transform.position).magnitude < senseDistance)
            {
                // If checking for a specific key...
                if (checkKeyId)
                {
                    // Do activation stuff if the key is found.
                    if (keyManager.CheckHasKey(requiredKeyId))
                    {
                        keyManager.RemoveKey(requiredKeyId);
                        logicManager.SetState(true);
                    }
                }
                // If any key will do...
                else
                {
                    // Do activation stuff if a key is found.
                    if (keyManager.CheckHasKey())
                    {
                        keyManager.RemoveKey();
                        logicManager.SetState(true);
                    }
                }
            }
        }
	}
}
