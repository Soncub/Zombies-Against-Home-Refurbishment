using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fix : MonoBehaviour
{
    private float coolDown = 0;
    private float nextFix = 1;

    public int points = 0;
    public int maxPoints = 10;

    void Update()
    {
        if (coolDown > 0)
        {
            coolDown -= Time.deltaTime;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Health collidedHealth = other.gameObject.GetComponent<Health>();

        if (collidedHealth == null)
            return;

        if (gameObject.tag == "Player" && other.gameObject.tag == "Wall")
        {
            if (coolDown <= 0 && points > 0)
            {
                Debug.Log("Player heals the wall.");
                collidedHealth.Fix(5);
                points--;
                coolDown = nextFix;
            }
            else if (points <= 0)
            {
                Debug.Log("Not enough points to heal the wall.");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PointCollect" && points < maxPoints)
        {
            StartCoroutine(CollectPointsOverTime(other));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "PointCollect")
        {
            StopAllCoroutines();
        }
    }

    private IEnumerator CollectPointsOverTime(Collider pointCollectObject)
    {
        while (points < maxPoints)
        {
            yield return new WaitForSeconds(1);
            points++;
            Debug.Log("Collected 1 point. Current points: " + points);
        }
    }
}
