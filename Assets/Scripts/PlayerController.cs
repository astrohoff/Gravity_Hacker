using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	Rigidbody2D player;
	public bool canjump, paused, disabled;
	private float disableTimeLength = 0.8f;
	Vector2 vel;
	int orientation; // 1 = down, 2 = up, 3 = left, 4 = right
	public float speed, jumptime, jumpstr, disableTime;
	Vector3 right, left, temp;
	Vector2 upjump, downjump, rightjump,leftjump, jump;
	Vector3 downgrav,upgrav,leftgrav,rightgrav;
	//fireball data
	public GameObject fireball;
	public Transform firePoint;


	void Start () {
		player = GetComponent<Rigidbody2D> ();
		canjump = true;
		paused = false;
		vel = new Vector2 (0, 0);
		speed = 8f;
		orientation = 1;
		disabled = false;

		jumptime = 0f;
		jumpstr = 8;
		upjump = new Vector2 (0, jumpstr);
		downjump = new Vector2 (0, -jumpstr);
		leftjump = new Vector2 (-jumpstr, 0);
		rightjump = new Vector2 (jumpstr, 0);
		jump = upjump; //default jump direction

		right = gameObject.transform.localScale;
		temp = right;
		temp.x = -temp.x;
		left = temp;

		downgrav = new Vector3 (0, 0, 0);
		upgrav = downgrav;
		upgrav.z = 180;

		rightgrav = downgrav;
		leftgrav = downgrav;

		rightgrav.z = 90;
		leftgrav.z = -90;
	}

	// Update is called once per frame
	void FixedUpdate(){
		
	}

	void Update () {
		if (paused) {
			Vector3 Still = new Vector3 (0, 0, 0);
			Still.x = gameObject.transform.position.x;
			Still.y = gameObject.transform.position.y;
			Still.z = gameObject.transform.position.z;
			gameObject.transform.position = Still;
		} else {
			if (!disabled) {
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

				if (Input.GetKeyUp ("d") || Input.GetKeyUp ("a")) {
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

						} else if (orientation == 2) {
							jump = downjump;
							jump.x = player.velocity.x;
							player.velocity = jump;

						} else if (orientation == 3) {
							jump = rightjump;
							jump.y = player.velocity.y;
							player.velocity = jump;

						} else if (orientation == 4) {
							jump = leftjump;
							jump.y = player.velocity.y;
							player.velocity = jump;

						}
					}
				}
			} else {
				if (Time.time - disableTime > disableTimeLength) {
					disabled = false;
				}
			}

			if (orientation == 1) {
				gameObject.transform.rotation = Quaternion.Euler (downgrav);
			} else if (orientation == 2) {
				gameObject.transform.rotation = Quaternion.Euler (upgrav);
			} else if (orientation == 3) {
				gameObject.transform.rotation = Quaternion.Euler (leftgrav);
			} else if (orientation == 4) {
				gameObject.transform.rotation = Quaternion.Euler (rightgrav);
			}


			if (Input.GetKeyDown ("up")) {
				orientation = 2;
				canjump = false;

				vel.y = vel.y*.1f; //play with dampening
				vel.x = vel.x*.1f;
				player.velocity = vel;

				Physics2D.gravity = 10 * Vector2.up;
			}
			if (Input.GetKeyDown ("down")) {
				orientation = 1;
				canjump = false;

				vel.y = vel.y*.1f; //play with dampening
				vel.x = vel.x*.1f;
				player.velocity = vel;

				Physics2D.gravity = 10 * Vector2.down;
			}
			if (Input.GetKeyDown ("left")) {
				orientation = 3;
				canjump = false;

				vel.y = vel.y*.1f; //play with dampening
				vel.x = vel.x*.1f;
				player.velocity = vel;

				Physics2D.gravity = 10 * Vector2.left;
			}
			if (Input.GetKeyDown ("right")) {
				orientation = 4;
				canjump = false;

				vel.y = vel.y*.1f; //play with dampening
				vel.x = vel.x*.1f;
				player.velocity = vel;

				Physics2D.gravity = 10 * Vector2.right;
			}


			if (Input.GetKeyDown ("f")) {			
				Instantiate (fireball, firePoint.position, firePoint.rotation);

			}


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

	public void disable(float length){
		disableTimeLength = length;
		disabled = true;
		disableTime = Time.time;

	}
}
