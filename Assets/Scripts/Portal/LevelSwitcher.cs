using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitcher : MonoBehaviour {
    public string nextSceneName = "";
	private float initialGravityMagnitude;

	private void Awake(){
		initialGravityMagnitude = Physics2D.gravity.magnitude;
	}

	private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {
			Physics2D.gravity = initialGravityMagnitude * Vector2.down;
            SceneManager.LoadScene(nextSceneName);
        }
    }

	public void LoadScene(){
		Physics2D.gravity = initialGravityMagnitude * Vector2.down;
		SceneManager.LoadScene(nextSceneName);
		Time.timeScale = 1;
	}

	public void exit_game(){
		Application.Quit ();
	}
		
}
