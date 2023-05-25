using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossController : MonoBehaviour {

    private Transform player;
    private NavMeshAgent navMeshAgent;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        this.navMeshAgent.SetDestination(this.player.position);
    }
}
