using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceController : MonoBehaviour {

	// Use this for initialization
	Vector3 offset;
	void Start () {
		offset = new Vector3 (-.01f, .01f, 0);
	}

	// Update is called once per frame
	void Update () {
		if (gameObject.transform.position.x < -10) {
			offset.x = -offset.x;
			offset.y = -offset.y;
		} 
		if (gameObject.transform.position.x > 0) {
			offset.x = -offset.x;
			offset.y = -offset.y;
		}
		gameObject.transform.position = gameObject.transform.position + offset;
	}
}
