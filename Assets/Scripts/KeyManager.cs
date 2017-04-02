using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour {
    // Key ids.
    public List<int> keys;
    public GameObject keyPrefab;

    private void Awake()
    {
    }

	public void AddKey(int keyId)
    {
        keys.Add(keyId);
    }

    public void RemoveKey()
    {
        if(keys.Count > 0)
        {
            keys.Remove(keys[0]);
        }
    }

    public void DropKey()
    {
        if(keys.Count > 0)
        {
            GameObject keyObj = Instantiate(keyPrefab);
            keyObj.transform.position = transform.position;
            keyObj.GetComponent<KeyBehavior>().keyId = keys[0];
            RemoveKey(keys[0]);
        }
    }

    public void RemoveKey(int keyId)
    {
        keys.Remove(keyId);
    }

    public bool CheckHasKey()
    {
        return keys.Count > 0;
    }

    public bool CheckHasKey(int keyId)
    {
        return keys.Contains(keyId);
    }

}
