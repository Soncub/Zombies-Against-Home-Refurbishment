using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int health;
    public int maxHealth;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.tag == "Wall")
        {
            maxHealth = 10;
        }
        if (gameObject.tag == "Player")
        {
            maxHealth = 5;
        }
            health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int amount)
    {
        health -= amount;

        if(health <= 0)
        {
            if(gameObject.tag == "Wall")
            {
                Destroy(gameObject);
            }
            if (gameObject.tag == "Player")
            {
                SceneManager.LoadScene(0);
            }

        }
    }

    public void Fix(int amount)
    {
        health += amount;
    }
}
