using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazerManager : MonoBehaviour {
	bool count,top;
	public GameObject lazertrap, lazertrap1;
	public Transform spawnposition,spawnposition1;
	// Use this for initialization
	void Start () {
		count = true;
		top = false;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D coll){
		if(coll.CompareTag("boss")){
			if (!count) {
				if (top) {
					Instantiate (lazertrap, spawnposition.position, spawnposition.rotation);
					top = false;
				} else {
					Instantiate (lazertrap1, spawnposition1.position, spawnposition.rotation);
					top = true;
				}
				count = true;
			} else {
				count = false;
			}
		}
	}
}
