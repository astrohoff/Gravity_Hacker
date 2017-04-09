using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitcher : MonoBehaviour {
    public string nextSceneName = "";
	private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
