using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lasertrapcontroler : MonoBehaviour {

	// Use this for initialization
	Vector2 vel, vel1;
	public float speed, timer;
	int spot;

	void Start () {
		spot = Random.Range (-3, 14);
		Vector3 temp = new Vector3 ((float)spot, gameObject.transform.GetChild (0).position.y);
		gameObject.transform.GetChild (0).position = temp;
		speed = 6f;
		vel = new Vector2 (0, -speed);
		vel1 = new Vector2 (0, 0);
		timer = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<Rigidbody2D> ().velocity = vel;
		//vel1.y = vel.y;
		//gameObject.transform.GetChild (0).GetComponent<Rigidbody2D> ().velocity = vel1;
		if (Time.time - timer > 3.1) {
			Destroy (gameObject);
		}
		if (Time.time - timer > 2) {
			gameObject.GetComponentsInChildren<Collider2D> ()[0].isTrigger = false;
			gameObject.GetComponentsInChildren<Collider2D> ()[1].isTrigger = false;
		}
	}
}
