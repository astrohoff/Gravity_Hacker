using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIcontroller : MonoBehaviour {

	Rigidbody2D player;
	bool canjump, shouldjump;
	Vector2 vel,jump;
	public float jumpstr;


	// Use this for initialization
	void Start () {
		player = GetComponent<Rigidbody2D> ();
		canjump = true;
		shouldjump = false;
		vel = new Vector2 (0, 0);


		jumpstr = 7;
		jump = new Vector2 (0, jumpstr);

	}
	
	// Update is called once per frame
	void Update () {
		if (shouldjump) {
			if (canjump) {
				canjump = false;
				player.velocity = jump;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D coll){
		if(coll.CompareTag("fireball")){
			shouldjump = true;
		}
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.CompareTag ("ground")) {
			canjump = true;
			shouldjump = false;
		}
	}
}




















/*void Update () {
	if (shouldjump) {
		if (canjump) {
			canjump = false;
			player.velocity = jump;
		}
	}
}

void OnTriggerEnter2D(Collider2D coll){
	if (coll.gameObject.CompareTag ("fireball")) {
		shouldjump = true;
		canjump = true;
	}
}

void OnCollisionEnter2D(Collision2D coll){
	if (coll.gameObject.CompareTag ("ground")) {
		canjump = true;
		shouldjump = false;
	}
}*/