using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingPlayerController : MonoBehaviour {

	// Use this for initialization
	float angle, speed, timer;
	Vector2 velocity;
	void Start () {
		speed = 4f;
		angle = gameObject.transform.rotation.eulerAngles.z;
		angle = angle * Mathf.Deg2Rad;
		velocity.x = Mathf.Cos (angle + Mathf.PI/2) * speed;
		velocity.y = Mathf.Sin (angle + Mathf.PI/2) * speed;
		gameObject.GetComponent<Rigidbody2D> ().velocity = velocity;
		timer = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.Rotate (new Vector3 (0, 0, .5f));
		if(Time.time - timer > 20){
			Destroy (gameObject);
		}
	}
}
