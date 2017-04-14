using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazertrapcontroller1 : MonoBehaviour {


	Vector2 vel, vel1;
	public float speed, timer;
	int spot;

	// Use this for initialization
	void Start () {
		spot = Random.Range (-1, 9);
		Vector3 temp = new Vector3 (gameObject.transform.GetChild (0).position.x, (float)spot);
		gameObject.transform.GetChild (0).position = temp;
		speed = 6;
		vel = new Vector2 (speed, 0);
		vel1 = new Vector2 (0, 0);
		timer = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<Rigidbody2D> ().velocity = vel;
		//vel1.y = vel.y;
		//gameObject.transform.GetChild (0).GetComponent<Rigidbody2D> ().velocity = vel1;
		if (Time.time - timer > 4.8f) {
			Destroy (gameObject);
		}
		if (Time.time - timer > 2) {
			gameObject.GetComponentsInChildren<Collider2D> ()[0].isTrigger = false;
			gameObject.GetComponentsInChildren<Collider2D> ()[1].isTrigger = false;
		}
	}
}
