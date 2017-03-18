using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour {
    public float health = 2;
    public float invincibilityTime = 1f;
    public bool isInvicible = false;

    public void TakeDamage(float damage)
    {
        if (!isInvicible)
        {
            health -= damage;
            if (health <= 0)
            {
                Die();
            }
            else
            {
                StartCoroutine(InvicibilityRoutine());
            }
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private IEnumerator InvicibilityRoutine()
    {
        isInvicible = true;
        yield return new WaitForSeconds(invincibilityTime);
        isInvicible = false;
    }
}
