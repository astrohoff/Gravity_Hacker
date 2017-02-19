using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovemnt : MonoBehaviour {
	
	Vector2 vel;
	Rigidbody2D player;
	public float speed;
	bool canjump;
	int jumpcount;
	Vector3 forward,backward,temp;
	Quaternion temp1;
	Transform upgrav,downgrav,leftgrav,rightgrav;
	double jumptime;
	public float jumpscale,firetime;
	public float jumpdur,groundspeed,aircalib;
	public bool paused, jumped;
	public Transform firePoint;
	public GameObject fireball;
	int orientation = 1; //1 is normal gravity, 2 is up, 3 is right, 4 is left
	Vector3 right, left;
	float gravmag = 500;


	void Start () {
		vel = new Vector2 (0, 0);
		right = new Vector3 (gravmag, 0, 0);
		left = new Vector3 (-gravmag, 0, 0);
		player = GetComponent<Rigidbody2D> ();
		canjump = true;
		jumpcount = 0;
		temp = new Vector3 (1, 1, 0);
		player.transform.localScale = temp;
		forward = player.transform.localScale;
		backward = forward;
		backward.x = (-1) * backward.x;

		//orientations for gravity
		downgrav = player.transform;
		upgrav = downgrav;
		temp = downgrav.transform.localScale;
		temp.y = -temp.y;
		upgrav.localScale = temp;
		temp1 = new Quaternion (0, 0, -90,0);
		leftgrav = downgrav;
		leftgrav.transform.localRotation = temp1;
		temp1.z = 90;
		rightgrav = downgrav;
		rightgrav.transform.localRotation = temp1;
		// end orientations

		jumptime = 0;
		jumpscale = 60;
		jumpdur = 1;
		speed = 1;
		groundspeed = 11;
		paused = false;
		jumped = false;
		orientation = 1;
		//aircalib = 1;
	}

	// Update is called once per frame
	void FixedUpdate(){
	}
	void Update () {
		if (!paused) {
			if (Input.GetKey ("d")) {
				if (orientation == -2) {
					vel.y = -groundspeed * speed;
					temp = forward;
					temp.y = gameObject.transform.localScale.y;
					player.transform.localScale = temp;
				} else {
					vel.x = groundspeed * speed;
					temp = forward;
					temp.y = gameObject.transform.localScale.y;
					player.transform.localScale = temp;
				}
			} else if (Input.GetKey ("a")) {
				if (orientation == -2) {
					vel.y = groundspeed * speed;
					temp = backward;
					temp.y = gameObject.transform.localScale.y;
					player.transform.localScale = temp;
				} else {
					vel.x = -groundspeed * speed;
					temp = backward;
					temp.y = gameObject.transform.localScale.y;
					player.transform.localScale = temp;
				}
			} else {
				vel.x = 0;
				vel.y = 0;
			}

			//jumping
			if (Input.GetKey ("space")) {
				if (canjump) {
					canjump = false;
					jumpcount += 1;
					jumptime = Time.time;
					jumped = true;
					//player.AddForce(jump);
				}
			}
			if (!canjump && jumped) {
				if (orientation == 1) {
					vel.y = (float)(-jumpscale * jumpdur / 2 * (Time.time - jumptime) + jumpscale * jumpdur * jumpdur / 4);
				} else if (orientation == -1) {
					vel.y = (float)((-1) * (-jumpscale * jumpdur / 2 * (Time.time - jumptime) + jumpscale * jumpdur * jumpdur / 4));
				} else if (orientation == -2) {
					vel.x = (float)((1) * (-jumpscale * jumpdur / 2 * (Time.time - jumptime) + jumpscale * jumpdur * jumpdur / 4));
				}
			} //else {
				//vel.y = 0;
				//vel.x = 0;
			//}


			//attacking
			if (Input.GetKey ("f")) {
				if (Time.time - firetime > .15f) {
					Instantiate (fireball, firePoint.position, firePoint.rotation);
					firetime = Time.time;
				}
			}

			//testing player alignment
			if (Input.GetKeyUp ("j")) {
				
				Vector3 test2 = new Vector3 (1, -1, 0);
				player.transform.localScale = test2;
			}

			//vertical gravity

			if (Input.GetKeyUp ("1")) {
				player.gravityScale = 20;
				//Vector3 flip = new Vector3 (0, 0, 0);
				//flip = gameObject.transform.localScale;
				//flip.y = -flip.y;
				//gameObject.transform.localScale = flip;
				player.transform.localRotation = downgrav.localRotation;
				orientation = 1;
				canjump = false;
			}

			if (Input.GetKeyUp ("2")) {
				player.gravityScale = -20;
				//Vector3 flip = new Vector3 (0, 0, 0);
				//flip = gameObject.transform.localScale;
				//flip.y = -flip.y;
				//gameObject.transform.localScale = flip;
				orientation = -1;
				canjump = false;
			}

			//horizontal gravity
			if (Input.GetKeyUp ("3")) {
				player.gravityScale = 0;
				vel.x = 0;
				vel.y = 0;
				Vector3 flip = new Vector3 (0, 0, -90);
				gameObject.transform.Rotate(flip);
				canjump = false;
				orientation = -2;
				flip = new Vector3 (-gravmag, 0, 0);
				player.AddForce(flip);
			}

			if (orientation == -2 && !jumped) {
				//player.AddForce (left);
				Physics2D.gravity = Vector2.left;
			} else if (orientation == 2 && !jumped) {
				player.AddForce (right);
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
