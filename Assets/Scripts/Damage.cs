using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public float invincible = 0;
    public float nextHit = 1;

    public float enemyDamage = 1f;
    public float damageIncrease = 0.5f;
    public float timeToIncreaseDamage = 30f;
    public float damageIncreaseTimer = 0f;
    [SerializeField]
    private Animator animator;

    void Update()
    {
        if (invincible > 0)
        {
            invincible -= Time.deltaTime;
        }

        damageIncreaseTimer += Time.deltaTime;
        if (damageIncreaseTimer >= timeToIncreaseDamage)
        {
            enemyDamage += damageIncrease;
            damageIncreaseTimer = 0f;
            Debug.Log("Enemy damage increased. New damage: " + enemyDamage);
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
                    //animator.SetBool("Attack", true);
                    Debug.Log("Enemy damages the wall.");
                    collidedHealth.TakeDamage(Mathf.FloorToInt(enemyDamage));
                    animator.SetBool("Attack", false);
                }
                else if (collision.gameObject.tag == "Player")
                {
                    Debug.Log("Enemy damages the player.");
                    collidedHealth.TakeDamage(Mathf.FloorToInt(enemyDamage));
                }
                invincible = nextHit;
            }
        }
    }
}
