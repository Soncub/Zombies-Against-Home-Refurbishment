using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    private float invincible = 0;
    private float nextHit = 1;
    void Start()
    {
        
    }

    void Update()
    {
        if(invincible > 0)
        {
            invincible -= Time.deltaTime;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (invincible <= 0)
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(2);
            invincible = nextHit;
        }
    }
}
