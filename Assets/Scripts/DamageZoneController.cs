using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class DamageZoneController : MonoBehaviour {
    public float damageAmount = 1;
    public float pushbackAmount = 1f;
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
                Vector2 pushBackForce = GetPushBackDirection(collision) * pushbackAmount;
                collision.rigidbody.AddForce(pushBackForce);
            }
        }
    }

    // Get the direction an object should be pushed in when it contacts the damage zone.
    // Returns direction in world space.
    private Vector2 GetPushBackDirection(Collision2D collision)
    {
        // Get average collision position.
        Vector2 averagePoint = Vector2.zero;
        for(int i = 0; i < collision.contacts.Length; i++)
        {
            averagePoint += collision.contacts[i].point;
        }
        averagePoint /= collision.contacts.Length;
        // Convert position from world space to local (damage zone) space.
        averagePoint = transform.InverseTransformPoint(averagePoint);

        // Check for the different possible collision positions and return corresponding directions.
        Vector2 colliderMax = transform.InverseTransformPoint(damageZoneCollider.bounds.max);
        Vector2 colliderMin = transform.InverseTransformPoint(damageZoneCollider.bounds.min);
        Vector2 padding = damageZoneCollider.bounds.extents * pushbackZonePadding;
        Vector2 pushBackDirection;
        // Between zone sides.
        if (averagePoint.x < colliderMax.x  - padding.x && averagePoint.x > colliderMin.x + padding.x) {
            // Top.
            if (averagePoint.y >= 0)
            {
                pushBackDirection = Vector2.up;
            }
            // Bottom.
            else
            {
                pushBackDirection = Vector2.down;
            }
        }
        // On zone sides.
        else
        {
            // Right.
            if(averagePoint.x > 0)
            {
                pushBackDirection = Vector2.right;
            }
            // Left.
            else
            {
                pushBackDirection = Vector2.left;
            }
        }
        // To do: corners.
        return pushBackDirection;
    }
}
