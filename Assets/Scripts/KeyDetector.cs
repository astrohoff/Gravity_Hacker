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
		if(logicManager.GetState() && (player.transform.position - transform.position).magnitude < senseDistance)
        {
            if (checkKeyId)
            {
                if (keyManager.CheckHasKey(requiredKeyId))
                {
                    keyManager.RemoveKey(requiredKeyId);
                }
            }
        }
	}
}
