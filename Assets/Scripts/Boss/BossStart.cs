using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStart : MonoBehaviour {
	public Vector3 danisgay;
	public GameObject temp;
	public float timer;
	public GameObject player;

	// Use this for initialization
	void Start () {
		danisgay = new Vector3 (45, 8, temp.GetComponent<Transform>().position.z);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D(Collider2D coll){
		if(coll.CompareTag("Player")){
			temp.GetComponent<Transform>().position = danisgay;
			temp.GetComponent<CameraController> ().releasePlayer ();
			gameObject.GetComponent<BoxCollider2D> ().isTrigger = false;
			player.GetComponent<Transform>().position = new Vector3 (27, 0, 0);
		}
	}
}
