using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarManager : MonoBehaviour {

	// Use this for initialization
	public GameObject boss;
	public Transform left, right;
	float hp, maxhp, increment, lasthp, width;
	void Start () {
		hp = boss.GetComponent<HealthManager> ().health;
		maxhp = hp;
		lasthp = hp;
		increment = 1f / maxhp;

		width = right.position.x - left.position.x;
		width = width / 2;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 temp = gameObject.transform.localScale;
		hp = boss.GetComponent<HealthManager> ().health;
		temp.x = hp * increment;
		gameObject.transform.localScale = temp;
		//if (hp < lasthp) {
			/*Debug.Log (boss.transform.rotation.eulerAngles.z);
			if (boss.transform.rotation.eulerAngles.z == 90) {
				gameObject.transform.position = gameObject.transform.position - new Vector3 (0, (width / maxhp) * (lasthp - hp), 0);
				Debug.Log ("taking damage while drav = right");
			} else if (boss.transform.rotation.eulerAngles.z == 270) {
				gameObject.transform.position = gameObject.transform.position + new Vector3 (0, (width / maxhp) * (lasthp - hp), 0);
				Debug.Log ("taking damage while drav = left");
			}
			else if (boss.transform.localScale.x > 0) {
				gameObject.transform.position = gameObject.transform.position - new Vector3 ((width / maxhp) * (lasthp - hp), 0, 0);
			}
			else if (boss.transform.localScale.x < 0) {
				gameObject.transform.position = gameObject.transform.position + new Vector3 ((width / maxhp) * (lasthp - hp), 0, 0);
			}*/
		//	gameObject.transform.localPosition = gameObject.transform.localPosition - new Vector3 ((width / maxhp) * (lasthp - hp), 0, 0);
	//	}
		//lasthp = hp;
	}
}
