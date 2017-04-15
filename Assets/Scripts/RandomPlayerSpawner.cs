using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPlayerSpawner : MonoBehaviour {

	// Use this for initialization
	public GameObject Player, Alien, spawn1, spawn2, spawn3, spawn4;

	void Start () {

		//Instantiate (Alien, spawn1.transform.position, spawn1.transform.rotation);
		//Instantiate (Alien, spawn2.transform.position, spawn2.transform.rotation);
		//Instantiate (Player, spawn3.transform.position, spawn3.transform.rotation);
		//Instantiate (Player, spawn4.transform.position, spawn4.transform.rotation);

	}
	
	// Update is called once per frame
	void Update () {
		
		if (Random.Range (1, 1000) < 5) {
			float f = Random.Range (1, 5);
			float cf = Random.Range (1, 100);
			if (f < 2) {
				if (cf < 50) {
					Instantiate (Alien, spawn1.transform.position, spawn1.transform.rotation);	
				} else {
					Instantiate (Player, spawn1.transform.position, spawn1.transform.rotation);	
				}
			} else if (f < 3) {
				if (cf < 50) {
					Instantiate (Alien, spawn2.transform.position, spawn2.transform.rotation);	
				} else {
					Instantiate (Player, spawn2.transform.position, spawn2.transform.rotation);	
				}

			} else if (f < 4) {
				if (cf < 50) {
					Instantiate (Alien, spawn3.transform.position, spawn3.transform.rotation);	
				} else {
					Instantiate (Player, spawn3.transform.position, spawn3.transform.rotation);	
				}

			} else {
				if (cf < 50) {
					Instantiate (Alien, spawn4.transform.position, spawn4.transform.rotation);	
				} else {
					Instantiate (Player, spawn4.transform.position, spawn4.transform.rotation);	
				}
				
			}



		}
	}
}
