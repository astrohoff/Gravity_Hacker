using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTrigger : MonoBehaviour {

	// Use this for initialization
	public GameObject platform;
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D coll){
		if(coll.CompareTag("ground")){
			Debug.Log ("hello");
			platform.GetComponent<movingPlatform> ().speed = -platform.GetComponent<movingPlatform> ().speed;
		}
	}
}
