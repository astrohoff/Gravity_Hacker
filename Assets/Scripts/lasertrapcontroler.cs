using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lasertrapcontroler : MonoBehaviour {

	// Use this for initialization
	Vector2 vel;
	public float speed;
	void Start () {
		speed = 3;
		vel = new Vector2 (0, -speed);
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<Rigidbody2D> ().velocity = vel;
	}
}
