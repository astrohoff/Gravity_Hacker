using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class for testing stuff with gravity direction changes.
// Will be replaced by actual gravity changing script when that is integrated.
public class GravityTester : MonoBehaviour {

    public Vector2 gravityDirection;
    public bool updateGravity = false;
    private float gravityMagnitude;

    private void Start()
    {
        gravityDirection = Physics2D.gravity.normalized;
        gravityMagnitude = Physics2D.gravity.magnitude;
    }

    private void FixedUpdate()
    {
        if (updateGravity)
        {
            Physics2D.gravity = gravityDirection * gravityMagnitude;
            updateGravity = false;
        }
    }
}
