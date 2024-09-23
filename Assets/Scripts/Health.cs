using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Health : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public TextMeshProUGUI healthText;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.tag == "Wall")
        {
            maxHealth = 10;
        }
        if (gameObject.tag == "Player")
        {
            maxHealth = 1;
        }
            health = maxHealth;

        healthText.text = "Health: " + health;

        if (healthText == null)
        {
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int amount)
    {
        health -= amount;
        healthText.text = "Health: " + health;

        if (health <= 0)
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
        healthText.text = "Health: " + health;
        health = Mathf.Min(health, maxHealth);
    }
}
