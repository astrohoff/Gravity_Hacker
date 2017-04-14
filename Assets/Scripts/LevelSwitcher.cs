using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitcher : MonoBehaviour {
    public string nextSceneName = "";
	private Vector2 initialGravity;

	private void Awake(){
		initialGravity = Physics2D.gravity;
	}

	private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {
			Physics2D.gravity = initialGravity;
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
