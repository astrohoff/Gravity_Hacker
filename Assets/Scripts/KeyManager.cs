using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour {
    public List<int> keys;

    private void Awake()
    {
        keys = new List<int>();
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
