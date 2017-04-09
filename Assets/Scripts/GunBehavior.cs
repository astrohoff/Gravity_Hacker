using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehavior : MonoBehaviour {
	public GameObject bulletPrefab;
	public Transform bulletSpawn;

	public void Fire(){
		GameObject newBullet = Instantiate (bulletPrefab);
		newBullet.transform.SetParent (bulletSpawn);
		newBullet.transform.localPosition = Vector3.zero;
		newBullet.transform.localRotation = Quaternion.identity;
	}
}
