using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ControlaBoss : MonoBehaviour {

    private Transform player;
    private NavMeshAgent agent;

    private void Start()
    {
        this.player = GameObject.FindWithTag("Player").transform;
        this.agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        agent.SetDestination(player.position);
    }
}
