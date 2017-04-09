using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour {
	public float speed = 10f;
	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D> ().velocity = transform.right * speed;
	}
	
	private void OnCollisionEnter2D(Collision2D collision){
		Destroy (gameObject);
	}
}
