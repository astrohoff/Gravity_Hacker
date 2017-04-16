using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Controller : MonoBehaviour {

	public Transform spawn0, spawn1, spawn2, spawn3, spawn4;
	public GameObject missile;
	void Start () {
		//fireMissiles ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void fireMissiles(){
		Instantiate (missile, spawn0.position, spawn0.rotation);
		Instantiate (missile, spawn1.position, spawn1.rotation);
		Instantiate (missile, spawn2.position, spawn2.rotation);
		Instantiate (missile, spawn3.position, spawn3.rotation);
		Instantiate (missile, spawn4.position, spawn4.rotation);
	}
}
