using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class DamageZoneController : MonoBehaviour {
    public float damageAmount = 1;
    public float pushbackAmount = 1f;
    // The size of the area
    public float pushbackZonePadding = 0.1f;

    private BoxCollider2D damageZoneCollider;

    private void Awake()
    {
        damageZoneCollider = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        HealthManager healthManager = collision.gameObject.GetComponent<HealthManager>();
        if(healthManager != null)
        {
            if (!healthManager.isInvicible)
            {
                healthManager.TakeDamage(damageAmount);
				collision.gameObject.GetComponent<PlayerController> ().disable ();
                Vector2 pushBackForce = GetPushBackDirection(collision) * pushbackAmount;
                collision.rigidbody.AddForce(pushBackForce);
            }
        }
    }

    // Gets the direction to push the player based on what side of the collider was hit.
    private Vector2 GetPushBackDirection(Collision2D collision)
    {
        // Get the average collision point (in case there are multiple).
        Vector2 collisionPoint = GetAverageCollisionPoint(collision);

        // Determine direction based on what part of the collider was hit.
        // Because collisions can happen below the surface of a collider (due to finite physics resolution)
        // determining the side hit from the collision position can be ambiguous around corners.
        // To handle this, vertical and horizontal sides are checked independantly and can both
        // be added to the pushback direction.
        // Padding is added to side bounds a zone where a side hit is recognized.
        Vector2 pushbackDirection = Vector2.zero;
        // Get vertical pushback.
        // Check if between left and right sides.
        if(collisionPoint.x > damageZoneCollider.bounds.min.x + pushbackZonePadding)
        {
            if(collisionPoint.x <= damageZoneCollider.bounds.max.x - pushbackZonePadding)
            {
                // If top...
                if(collisionPoint.y > damageZoneCollider.bounds.center.y)
                {
                    pushbackDirection += Vector2.up;
                }
                // If bottom...
                else
                {
                    pushbackDirection += Vector2.down;
                }
            }
        }
        // Add horizontal pushback.
        // Check if between top and bottom.
        if (collisionPoint.y >= damageZoneCollider.bounds.min.y + pushbackZonePadding)
        {
            if (collisionPoint.y < damageZoneCollider.bounds.max.y - pushbackZonePadding)
            {
                // If left...
                if(collisionPoint.x < damageZoneCollider.bounds.center.x)
                {
                    pushbackDirection += Vector2.left;
                }
                // If right.
                else
                {
                    pushbackDirection += Vector2.right;
                }
            }
        }
        // If a corner was hit, pushbackDirection will still  be zero.
        // In this case just use the direction from the center of the collider to the hit point.
        if(pushbackDirection == Vector2.zero)
        {
            pushbackDirection = collisionPoint - (Vector2)damageZoneCollider.bounds.center;
        }
        // Normalize so that the magnitude is conistent.
        pushbackDirection.Normalize();
        return pushbackDirection;
    }


    private Vector2 GetAverageCollisionPoint(Collision2D collision)
    {
        Vector2 collisionPoint = Vector2.zero;
        for (int i = 0; i < collision.contacts.Length; i++)
        {
            collisionPoint += collision.contacts[i].point;
        }
        collisionPoint = collisionPoint / collision.contacts.Length;
        return collisionPoint;
    }
}
