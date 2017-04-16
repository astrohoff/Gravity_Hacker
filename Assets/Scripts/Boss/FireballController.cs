using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballController : MonoBehaviour {
	private float temp;
	private float speed;

	Vector3 newScale;
	// Use this for initialization
	void Start () {
		speed = 12f;
		temp = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		
		gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0f, -speed);
		if (Time.time - temp > 2) {
			Destroy (gameObject);
		}
		
	}

	void OnTriggerEnter2D(Collider2D other){

	}

	void OnCollisionEnter2D(Collision2D other){

	}
}
