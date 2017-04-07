using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public EnemyState state;
    public float maxWanderTime = 2.0f;
    public float minWanderTime = 0.5f;
    public float wanderSpeed = 0.5f;
    public float rotateTime = 0.5f;
    private float wanderTime = 0;
    private float stateTime = 0;
    private int direction;
    private float currentRotateTime = 0;
    private Vector2 rotateInitialUp = Vector2.up;

    public enum EnemyState { Wander, Engage};

    // Use this for initialization
    private void Start () {
		
	}

    // Update is called once per frame
    private void Update () {
        UpdateState();
        UpdateOrientation();
	}

    private bool CheckArrowKeyPressed()
    {
        bool arrowPress = Input.GetKeyDown(KeyCode.DownArrow);
        arrowPress = arrowPress || Input.GetKeyDown(KeyCode.LeftArrow);
        arrowPress = arrowPress || Input.GetKeyDown(KeyCode.UpArrow);
        arrowPress = arrowPress || Input.GetKeyDown(KeyCode.RightArrow);
        return arrowPress;
    }

    private void UpdateOrientation()
    {
        if (CheckArrowKeyPressed())
        {
            currentRotateTime = 0;
            rotateInitialUp = transform.up;
        }
        transform.up = Vector2.Lerp(rotateInitialUp, -Physics2D.gravity, currentRotateTime / rotateTime);
        currentRotateTime += Time.deltaTime;
    }

    private void UpdateState()
    {
        if (state == EnemyState.Wander)
        {
            if (stateTime >= wanderTime)
            {
                GenerateNewWander(true);
            }
            else
            {
                transform.position += transform.right * direction * wanderSpeed * Time.deltaTime;
                stateTime += Time.deltaTime;
            }
        }
    }

    private void GenerateNewWander(bool randomizeDirection)
    {
        stateTime = 0;
        wanderTime = Random.Range(minWanderTime, maxWanderTime);
        if (randomizeDirection)
        {
            if (Random.value > 0.5f)
            {
                direction = 1;
            }
            else
            {
                direction = -1;
            }
        }
        
    }

    private void OnCollisionEnter2D()
    {
        direction = -direction;
        GenerateNewWander(false);
    }
}
