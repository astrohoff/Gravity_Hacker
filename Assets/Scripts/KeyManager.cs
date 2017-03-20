using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour {
    private List<int> keys;

	public void AddKey(int keyId)
    {
        keys.Add(keyId);
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
