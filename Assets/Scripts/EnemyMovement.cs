using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;

    private void Awake()
    {
        player = GameObject.Find("Prototype Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            ChasePlayer();

    }

    private void ChasePlayer()
    {
            agent.SetDestination(player.position);
    }
}
