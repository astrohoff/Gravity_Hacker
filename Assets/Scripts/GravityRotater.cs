using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityRotater : MonoBehaviour
{
    public Transform playerPivot;
    public Transform level;
    public float currentGravityRotation = 0;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Gravity Down"))
        {
            SetGravityRotation(0);
        }
        else if (Input.GetButtonDown("Gravity Left"))
        {
            SetGravityRotation(90);
        }
        else if (Input.GetButtonDown("Gravity Up"))
        {
            SetGravityRotation(180);
        }
        else if (Input.GetButtonDown("Gravity Right"))
        {
            SetGravityRotation(270);
        }
    }

    private void SetGravityRotation(float angle)
    {
        float deltaAngle = angle - currentGravityRotation;
        level.RotateAround(playerPivot.position, Vector3.forward, deltaAngle);
        Camera.main.transform.RotateAround(playerPivot.position, Vector3.forward, deltaAngle);
        currentGravityRotation = angle;
    }
}
