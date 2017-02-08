using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovemnt : MonoBehaviour {
	
	Vector2 vel;
	Rigidbody2D player;
	public float speed;
	bool canjump;
	int jumpcount;
	Vector3 forward,backward;
	double jumptime;
	public float jumpscale,firetime;
	public float jumpdur,groundspeed,aircalib;
	public bool paused;
	public Transform firePoint;
	public GameObject fireball;

	void Start () {
		vel = new Vector2 (0, 0);
		player = GetComponent<Rigidbody2D> ();
		canjump = true;
		jumpcount = 0;
		forward = player.transform.localScale;
		backward = forward;
		backward.x = (-1) * backward.x;
		jumptime = 0;
		jumpscale = 60;
		jumpdur = 1;
		speed = 1;
		groundspeed = 11;
		paused = false;
		//aircalib = 1;
	}

	// Update is called once per frame
	void Update () {
		if (!paused) {
			if (Input.GetKey ("d")) {
				vel.x = groundspeed * speed;
				player.transform.localScale = forward;
				player.GetComponent<Rigidbody2D> ().gravityScale = -1;
			} else if (Input.GetKey ("a")) {
				vel.x = -groundspeed * speed;
				player.transform.localScale = backward;
			} else {
				vel.x = 0;
			}
			if (canjump) {
				if (Input.GetKey ("space")) {
					canjump = false;
					jumpcount += 1;
					jumptime = Time.time;
				}
			} else {
				vel.y = (float)(-jumpscale * jumpdur / 2 * (Time.time - jumptime) + jumpscale * jumpdur * jumpdur / 4);
			}
			if (Input.GetKey ("f")) {
				if (Time.time - firetime > .15f) {
					Instantiate (fireball, firePoint.position, firePoint.rotation);
					firetime = Time.time;
				}
			}
		}




	
		player.velocity = vel;
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.CompareTag ("ground")) {
			canjump = true;
		}
	}

	public void unpause(){
		paused = false;
	}

	public void pause(){
		paused = true;
	}
}
