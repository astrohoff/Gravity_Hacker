using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAlienFollow : MonoBehaviour {

	// Use this for initialization
	public GameObject bosscircle;
	void Start () {
		gameObject.transform.position = bosscircle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position = bosscircle.transform.position;
	}
}
