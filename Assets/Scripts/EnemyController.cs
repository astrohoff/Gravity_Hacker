using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controller for enemy ailen behavior.
public class EnemyController : MonoBehaviour {
    public EnemyState state;
	// Min & max time enemy wanders in a direction before choosing another random direction.
	// Combined into Vector2 for convenience.
	public Vector2 wanderTimeMinMax = new Vector2(0.5f, 2.0f);
	// Movement speed for wandering.
    public float wanderSpeed = 1.5f;

	// The speed that the enemies rotate (in degrees / second) at to match gravity orientation.
	public float rotateSpeed = 360.0f;
	// That angel of difference in orientation between enemy and gravity above which
	// rotation is applied.
	public float rotateThresholdAngle = 5.0f;
	// The max legnth of the current state, after which the state will be reevaluated / restarted.
    private float currentMaxStateTime = 0;
	// The length of time the current state has lasted without being reevaluated / restarted.
    private float currentStateTime = 0;
	private Rigidbody2D enemyRigidbody;
	private Transform player;
	public LayerMask playerRaycastLayers;

    public enum EnemyState { Wander, Engage};

	private void Awake(){
		enemyRigidbody = GetComponent<Rigidbody2D> ();
		player = GameObject.Find ("Player");
	}
    
    private void Update () {
		UpdateOrientation();
        UpdateState();
	}

    private void UpdateOrientation()
    {
		if (Vector2.Angle (transform.up, -Physics2D.gravity) > rotateThresholdAngle) {
			Vector3 rotAxis = Vector3.Cross (transform.up, -Physics2D.gravity);
			float rotAngle = rotateSpeed * Time.deltaTime;
			transform.Rotate (rotAxis, rotAngle);
		}
    }

    private void UpdateState()
    {
		// Initial state evaluation path determined by previous state.
        if (state == EnemyState.Wander)
        {
			// If the player is "spotted" switch to engage state.
			if (CheckCanSeePlayer ()) {
				state = EnemyState.Engage;
			} 
			// Else, enemy doesn't know where the player is, so keep wandering.
			else {				
				// If the enemy has wandered for the previously generated random length of time...
				if (currentStateTime >= currentMaxStateTime) {
					// Restart the wander state with a random length and direction.
					GenerateNewWander (true);
				} 
				// If the enemy still has more time to wander, move it.
				else {
					ApplyMovement (wanderSpeed);
				}
			}
        }
		// Increase currentStateTime by the length of this frame.
		currentStateTime += Time.deltaTime;
    }

	// Calculate and apply movement to enemy.
	private void ApplyMovement(float speed){
		Vector2 movementDirection = transform.right * transform.localScale.normalized.x;
		float movementDistace = speed * Time.deltaTime;
		transform.position = (Vector2)transform.position + movementDirection * movementDistace;
	}

	// Sets a new wander state with a randomized durration and optionally a
	// randomized forward direction.
    private void GenerateNewWander(bool randomizeDirection)
    {
		// Reset currentStateTime to 0.
		currentStateTime = 0;
		// Generate new random max time length for the new current state.
		currentMaxStateTime = Random.Range(wanderTimeMinMax.x, wanderTimeMinMax.y);
		// Optionally set a randomized forward direction.
		// This is optional because when the enemy runs into a wall it generates a new wander but
		// must make forward be away from the wall.
        if (randomizeDirection)
        {
            if (Random.value > 0.5f)
            {
				Vector3 localScale = transform.localScale;
				localScale.x = localScale.x * -1;
				transform.localScale = localScale;
            }
        }
    }

	private bool CheckCanSeePlayer(){
		Vector2 playerDirection = transform.position - player.position;
		Physics2D.Raycast (transform.position, playerDirection, float.MaxValue, playerRaycastLayers);
	}
		
	private void OnCollisionEnter2D(Collision2D collision)
    {
		if (collision.gameObject.tag != "Player") {
			// If the enemy runs into wall while wandering, generate a new
			// wander in the opposite direction.
			if (state == EnemyState.Wander) {
				Vector3 localScale = transform.localScale;
				localScale.x = localScale.x * -1;
				transform.localScale = localScale;
				GenerateNewWander (false);
			}
		}
    }
}
