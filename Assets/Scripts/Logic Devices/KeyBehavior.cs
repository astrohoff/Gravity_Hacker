using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBehavior : MonoBehaviour {
    public int keyId;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
		KeyManager keyManager = collision.gameObject.GetComponent<KeyManager>();
		if(keyManager != null)
        {
            keyManager.AddKey(keyId);
            Destroy(gameObject);
        }
    }
}
