using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarManager : MonoBehaviour {

	// Use this for initialization
	public GameObject boss;
	float hp, maxhp, increment, lasthp;
	void Start () {
		hp = boss.GetComponent<HealthManager> ().health;
		maxhp = hp;
		lasthp = hp;
		increment = 1f / maxhp;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 temp = gameObject.transform.localScale;
		hp = boss.GetComponent<HealthManager> ().health;
		temp.x = hp * increment;
		gameObject.transform.localScale = temp;
		if (hp < lasthp) {
			gameObject.transform.position = gameObject.transform.position - new Vector3 (.02f * (lasthp - hp), 0, 0);
		}
		lasthp = hp;
	}
}
