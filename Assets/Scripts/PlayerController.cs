using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	Rigidbody2D player;
	bool canjump, paused;
	Vector2 vel;
	int orientation; // 1 = down, 2 = up, 3 = left, 4 = right
	public float speed, jumptime, jumpstr;
	Vector3 right, left, temp;
	Vector2 upjump, downjump, rightjump,leftjump, jump;


	void Start () {
		player = GetComponent<Rigidbody2D> ();
		canjump = true;
		paused = false;
		vel = new Vector2 (0, 0);
		speed = 8f;
		orientation = 1;


		jumptime = 0f;
		jumpstr = 7;
		upjump = new Vector2 (0, jumpstr);
		downjump = new Vector2 (0, -jumpstr);
		leftjump = new Vector2 (-jumpstr, 0);
		rightjump = new Vector2 (jumpstr, 0);
		jump = upjump; //default jump direction

		right = gameObject.transform.localScale;
		temp = right;
		temp.x = -temp.x;
		left = temp;

	}

	// Update is called once per frame
	void FixedUpdate(){
		
	}

	void Update () {
		vel = player.velocity;
		if (Input.GetKey ("d")) {
			gameObject.transform.localScale = right;
			if (orientation == 1 || orientation == 2) {
				vel.x = speed;
			} 
			if (orientation == 3) {
				vel.y = -speed;
			}
			if (orientation == 4) {
				vel.y = speed;
			}
			player.velocity = vel;

		} else if (Input.GetKey ("a")) {
			gameObject.transform.localScale = left;
			if (orientation == 1 || orientation == 2) {
				vel.x = -speed;
			} 
			if (orientation == 3) {
				vel.y = speed;
			}
			if (orientation == 4) {
				vel.y = -speed;
			}
			player.velocity = vel;
		}

		if (Input.GetKeyUp ("d") || Input.GetKeyUp("a")) {
			if (orientation == 1 || orientation == 2) {
				vel.x = 0;
			} else if (orientation == 3 || orientation == 4) {
				vel.y = 0;
			}
			player.velocity = vel;
		}



		if (Input.GetKeyDown ("space")) {
			if (canjump) {
				canjump = false;
				jumptime = Time.time;
				if (orientation == 1) {
					jump = upjump;
					jump.x = player.velocity.x;
					player.velocity = jump;

				} 
				else if (orientation == 2) {
					jump = downjump;
					jump.x = player.velocity.x;
					player.velocity = jump;

				} 
				else if (orientation == 3) {
					jump = rightjump;
					jump.y = player.velocity.y;
					player.velocity = jump;

				} 
				else if (orientation == 4) {
					jump = leftjump;
					jump.y = player.velocity.y;
					player.velocity = jump;

				}
			}
		}

		if (Input.GetKeyDown ("up")) {
			orientation = 2;
			canjump = false;

			vel.y = 0;
			vel.x = 0;
			//player.velocity = vel;

			Physics2D.gravity = 10*Vector2.up;
		}
		if (Input.GetKeyDown ("down")) {
			orientation = 1;
			canjump = false;

			vel.y = 0;
			vel.x = 0;
			//player.velocity = vel;

			Physics2D.gravity = 10*Vector2.down;
		}
		if (Input.GetKeyDown ("left")) {
			orientation = 3;
			canjump = false;

			vel.y = 0;
			vel.x = 0;
			//player.velocity = vel;

			Physics2D.gravity = 10*Vector2.left;
		}
		if (Input.GetKeyDown ("right")) {
			orientation = 4;
			canjump = false;

			vel.y = 0;
			vel.x = 0;
			//player.velocity = vel;

			Physics2D.gravity = 10*Vector2.right;
		}


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
