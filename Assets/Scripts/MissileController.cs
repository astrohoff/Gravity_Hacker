using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour {

	// Use this for initialization
	Vector2 velocity, destination;
	Vector3 playerpos,missilepos;
	float angle, anglebetween;
	public float speed;
	public GameObject player;
	void Start () {
		speed = 4f;
		angle = gameObject.transform.rotation.eulerAngles.z;
		angle = angle * Mathf.Deg2Rad;
		velocity.x = Mathf.Cos (angle + Mathf.PI/2) * speed;
		velocity.y = Mathf.Sin (angle + Mathf.PI/2) * speed;
		gameObject.GetComponent<Rigidbody2D> ().velocity = velocity;
	}
	
	// Update is called once per frame
	void Update () {
		playerpos = player.transform.position;
		missilepos = gameObject.transform.position;
		//playerpos.Normalize ();
		//missilepos.Normalize ();
		destination.x = playerpos.x - missilepos.x;
		destination.y = playerpos.y - missilepos.y;
		destination.Normalize ();

		//computes new velocity
		angle = gameObject.transform.rotation.eulerAngles.z;
		angle = angle * Mathf.Deg2Rad;

		velocity = gameObject.GetComponent<Rigidbody2D> ().velocity;
		velocity.Normalize ();
		anglebetween = Vector2.Angle (velocity, destination);
		gameObject.transform.Rotate (new Vector3 (0, 0, anglebetween / 30));
		angle = gameObject.transform.rotation.eulerAngles.z;
		angle = angle * Mathf.Deg2Rad;
		velocity.x = Mathf.Cos (angle + Mathf.PI/2) * speed;
		velocity.y = Mathf.Sin (angle + Mathf.PI/2) * speed;




		gameObject.GetComponent<Rigidbody2D> ().velocity = velocity;


	}

	void OnTriggerEnter2D(Collider2D coll){
		Debug.Log ("asdf");
		if (coll.gameObject.CompareTag ("missile")) {
			float tempangle = Vector2.Angle (gameObject.GetComponent<Rigidbody2D>().velocity, coll.gameObject.GetComponent<Rigidbody2D>().velocity);
			gameObject.transform.Rotate(new Vector3(0,0,tempangle/3));
		}
	}
}
