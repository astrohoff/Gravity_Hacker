using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public float damptime = 0f;//0.5f;
	private Vector3 velocity = Vector3.zero;
	public Transform target;
	public float height;
	public bool onPlayer;

	// Use this for initialization
	void Start () {
		onPlayer = true;
	}

	// Update is called once per frame
	void Update () {
		if (onPlayer) {
			if (target) {
				height = 3.8f;//target.position.y + 2.8f;
				Vector3 point = gameObject.GetComponent<Camera> ().WorldToViewportPoint (target.position);
				Vector3 temp = new Vector3 (.5f, .5f, point.z);
				//float delta = target.position.x - gameObject.GetComponent<Camera> ().ViewportToWorldPoint (temp).x;
				float deltaY = target.position.y - gameObject.GetComponent<Camera> ().ViewportToWorldPoint (temp).y;
				Vector3 destination = new Vector3 (transform.position.x, height + transform.position.y + deltaY, transform.position.z);
				transform.position = Vector3.SmoothDamp (transform.position, destination, ref velocity, damptime, Mathf.Infinity, Time.deltaTime);
				gameObject.GetComponent<Camera> ().orthographicSize = 8; //test
			}
		}
	}

	public void releasePlayer(){
		onPlayer = false;
	}

	public void followPlayer(){
		onPlayer = true;
	}
}
