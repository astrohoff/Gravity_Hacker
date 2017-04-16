using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour {
    public float health = 2;
    public float invincibilityTime = 2f;
    public bool isInvicible = false;
    public Color damageColor = new Color(0.5f, 0.25f, 0.25f);
    public Color invincibleColor = new Color(0.25f, 0.25f, 0.25f);
    public float statusBlinkPeriod = 0.5f;
    public int damageBlinks = 2;

    private Material material;

    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

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
        KeyManager keyManager = GetComponent<KeyManager>();
        if(keyManager != null)
        {
            while(keyManager.keys.Count > 0)
            {
                keyManager.DropKey();
            }
			Destroy (keyManager);
        }
		StartCoroutine (DeathAnimationRoutine ());
    }

	private IEnumerator DeathAnimationRoutine(){
		material.color = Color.red;
		int frameCount = 30;
		Vector3 initialScale = transform.localScale;
		yield return new WaitForSeconds (0.25f);
		Vector3 scaleStep = initialScale / frameCount;
		for (int i = 0; i < frameCount; i++) {
			transform.localScale = Vector3.Lerp (initialScale, Vector3.zero, i / (float)frameCount);
			yield return null;
		}
		Destroy (gameObject);
	}

    private IEnumerator InvicibilityRoutine()
    {
        isInvicible = true;
        float remainingInvincibilityTime = invincibilityTime;
        float remainingBlinkTime = statusBlinkPeriod;
        int blinkCount = 0;
        while(remainingInvincibilityTime > 0)
        {
            if(remainingBlinkTime > statusBlinkPeriod / 2)
            {
                if(blinkCount < damageBlinks)
                {
                    material.SetColor("_AddColor", damageColor);
                }
                else
                {
                    material.SetColor("_AddColor", invincibleColor);
                }
                while(remainingInvincibilityTime > 0 &&  remainingBlinkTime > statusBlinkPeriod / 2)
                {
                    yield return null;
                    remainingInvincibilityTime -= Time.deltaTime;
                    remainingBlinkTime -= Time.deltaTime;
                }
            }
            else if(remainingBlinkTime > 0)
            {
                material.SetColor("_AddColor", Color.black);
                while(remainingInvincibilityTime > 0 && remainingBlinkTime > 0)
                {
                    yield return null;
                    remainingInvincibilityTime -= Time.deltaTime;
                    remainingBlinkTime -= Time.deltaTime;
                }
                blinkCount++;
                remainingBlinkTime = statusBlinkPeriod;
            }
        }

        isInvicible = false;
    }
}
