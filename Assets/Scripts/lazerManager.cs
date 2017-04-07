using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazerManager : MonoBehaviour {
	bool count;
	int spot;
	public GameObject lazertrap;
	public Transform spawnposition;
	// Use this for initialization
	void Start () {
		count = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D coll){
		if(coll.CompareTag("boss")){
			if (!count) {
				spot = Random.Range (-3, 13);
				Instantiate (lazertrap, spawnposition.position, spawnposition.rotation);
				count = true;
			} else {
				count = false;
			}
		}
	}
}
