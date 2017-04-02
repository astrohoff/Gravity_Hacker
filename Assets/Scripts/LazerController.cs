﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerController : MonoBehaviour {
    public Transform lazerBeam;
    public LayerMask raycastedLayers;
    private BoxCollider2D lazerCollider;
    private BoxCollider2D emitterCollider;

    private void Awake()
    {
        emitterCollider = GetComponent<BoxCollider2D>();
        lazerCollider = lazerBeam.GetComponent<BoxCollider2D>();
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        lazerCollider.enabled = false;
        emitterCollider.enabled = false;
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, float.MaxValue, raycastedLayers);
        if(hitInfo.collider != null)
        {
            lazerBeam.position = ((Vector2)transform.position + hitInfo.point) / 2;
            Vector2 lazerLength = transform.InverseTransformVector(new Vector2(hitInfo.distance, 0));
            lazerBeam.localScale = new Vector2(lazerLength.x, lazerBeam.localScale.y);
        }
        lazerCollider.enabled = true;
        emitterCollider.enabled = true;
	}
}
