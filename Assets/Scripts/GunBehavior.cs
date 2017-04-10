using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehavior : MonoBehaviour {
	public GameObject bulletPrefab;
	public Transform bulletSpawn;
	public float bulletSpeed = 20f;
	private Transform user;

	private void Awake(){
		user = transform.parent;
	}

	public void Fire(){
		GameObject newBullet = Instantiate (bulletPrefab);
		newBullet.transform.SetParent (bulletSpawn);
		newBullet.transform.localPosition = Vector3.zero;
		newBullet.transform.localRotation = Quaternion.identity;
		newBullet.GetComponent<Rigidbody2D> ().velocity = transform.right * bulletSpeed * user.localScale.normalized.x;
		newBullet.GetComponent<DamageZoneController> ().owner = transform.parent.gameObject;
		newBullet.transform.parent = null;
	}
}
