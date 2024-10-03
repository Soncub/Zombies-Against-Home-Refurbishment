using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Health : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public TextMeshProUGUI healthText;
    public Animator animator;
    private bool isDead = false;

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

        if (healthText != null)
        {
            healthText.text = "Health: " + health;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead) return;
    }

    public void TakeDamage(int amount)
    {
        if (isDead) return;

        health -= amount;

        health = Mathf.Max(health, 0);

        if (healthText != null)
        {
            healthText.text = "Health: " + health;
        }

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (isDead) return;

        isDead = true;

        if (animator != null)
        {
            animator.SetTrigger("Die");
        }

        if (gameObject.tag == "Wall")
        {
            if (animator != null)
            {
                StartCoroutine(HandleDeathAnimation());
            }
            else
            {
                Destroy(gameObject);
            }
        }
        if (gameObject.tag == "Player")
        {
            SceneManager.LoadScene(0);
        }
    }

    IEnumerator HandleDeathAnimation()
    {
        if (animator != null)
        {
            float animationLength = animator.GetCurrentAnimatorStateInfo(0).length;
            yield return new WaitForSeconds(animationLength);
        }

        Destroy(gameObject);
    }

    public void Fix(int amount)
    {
        if (isDead) return;

        health += amount;
        health = Mathf.Min(health, maxHealth);

        if (healthText != null)
        {
            healthText.text = "Health: " + health;
        }

        if (health >= maxHealth)
        {
            health = maxHealth;
            healthText.text = "Health: " + health;
        }
    }
}
