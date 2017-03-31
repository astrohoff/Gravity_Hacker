using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour {

	public GameObject movementtext, gravitytext, introtext, player;
	private float starttime, temp;
	public float readtime, latency;
	int step;

	// Use this for initialization
	void Start () {
		starttime = Time.time;
		readtime = 5;
		latency = 5;
		player.GetComponent<PlayerController> ().paused = true;
		step = 9;
	}

	// Update is called once per frame
	void Update () {
		//state controller

		if (Time.time > 2 && Time.time < 6) {
			step = 0;
		}
		else if (Time.time > 6 && Time.time < 12) {
			step = 1;
		}


		//state descriptions

		if (step == 0) {
			introtext.SetActive (true);
		}
		if (step == 1) {
			player.GetComponent<PlayerController> ().paused = false;
			introtext.SetActive (false);
			movementtext.SetActive (true);
		}

	}
}
