﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour {
	private void OnCollisionEnter2D(){
		
		Destroy (gameObject);
	}		
}
