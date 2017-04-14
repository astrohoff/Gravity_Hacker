using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatform : MonoBehaviour {

	// Use this for initialization
	Vector2 vel;
	public float speed;

	void Start () {
		speed = 3;
		vel = new Vector2 (speed, 0);
	}
	
	// Update is called once per frame
	void Update () {
		vel.x = speed;
		Debug.Log (speed);
		gameObject.GetComponent<Rigidbody2D> ().velocity =vel;

	}

	//void OnTriggerEnter2D(Collider2D coll){
		//if(coll.CompareTag("wallObject")){
		//	speed = -speed;
		//}
	//}
}
