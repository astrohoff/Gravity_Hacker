using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBehavior : MonoBehaviour {
    public int keyId;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            KeyManager keyManager = collision.gameObject.GetComponent<KeyManager>();
            keyManager.AddKey(keyId);
            Destroy(gameObject);
        }
    }
}
