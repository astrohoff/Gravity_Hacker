using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {

	Vector2 direction,left,up,right,down,temp; //preset directions
	Rigidbody2D boss;
	public float speed, tempx;
	public Transform middle;
	// Use this for initialization
	void Start () {
		right = new Vector2 (1, 0);
		left = new Vector2 (-1, 0);
		up = new Vector2 (0, 1);
		down = new Vector2 (0, -1);

		//direction = left;

		boss = GetComponent<Rigidbody2D> ();
		speed = 8;
	}
	
	// Update is called once per frame
	void Update () {
		boss.velocity = speed * direction;
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.CompareTag ("ground")) {
			direction = left;
		} else if (coll.gameObject.CompareTag ("leftwall")) {
			direction = up;
		} else if (coll.gameObject.CompareTag ("roof")) {
			direction = right;
		} else if (coll.gameObject.CompareTag ("rightwall")) {
			direction = down;
		} else if (coll.gameObject.CompareTag ("trcurve")) {
			temp.x = middle.position.x - boss.position.x;
			temp.y = middle.position.y - boss.position.y;
			temp = temp / temp.magnitude;
			tempx = temp.x;
			temp.x = -temp.y;
			temp.y = tempx;
			direction = temp;
			Debug.Log (direction);
		} else if (coll.gameObject.CompareTag ("tlcurve")) {

		} else if (coll.gameObject.CompareTag ("blcurve")) {

		} else if (coll.gameObject.CompareTag ("brcurve")) {

		}
	}
}
