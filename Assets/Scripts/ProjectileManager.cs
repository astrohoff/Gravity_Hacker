using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour {
	bool count;
	public GameObject fireball;
	public Transform firePoint;
	// Use this for initialization
	void Start () {
		count = false;
	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D coll){
		if(coll.CompareTag("boss")){
			if (!count) {
				Instantiate (fireball, firePoint.position, firePoint.rotation);
				count = true;
			} else {
				count = false;
			}
		}
	}
}
