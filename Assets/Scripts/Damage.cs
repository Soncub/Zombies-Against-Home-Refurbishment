using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    private float invincible = 0;
    private float nextHit = 1;
    private float coolDown = 0;
    private float nextFix = 1;

    void Update()
    {
        if (invincible > 0)
        {
            invincible -= Time.deltaTime;
        }

        if (coolDown > 0)
        {
            coolDown -= Time.deltaTime;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        Health collidedHealth = collision.gameObject.GetComponent<Health>();

        if (collidedHealth == null)
            return;

        if (gameObject.tag == "Enemy")
        {
            if (invincible <= 0)
            {
                if (collision.gameObject.tag == "Wall")
                {
                    Debug.Log("Enemy damages the wall.");
                    collidedHealth.TakeDamage(1);
                }
                else if (collision.gameObject.tag == "Player")
                {
                    Debug.Log("Enemy damages the player.");
                    collidedHealth.TakeDamage(1);
                }
                invincible = nextHit;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Health collidedHealth = other.gameObject.GetComponent<Health>();

        if (collidedHealth == null)
            return;

        if (gameObject.tag == "Player" && other.gameObject.tag == "Wall")
        {
            if (coolDown <= 0)
            {
                Debug.Log("Player heals the wall.");
                collidedHealth.Fix(2);
                coolDown = nextFix;
            }
        }
    }
}
