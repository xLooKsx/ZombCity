using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossController : MonoBehaviour, IDamage
{

    private GameObject player;
    private NavMeshAgent navMeshAgent;
    private Status bossStatus;
    private AnimationController animationController;
    private Movement movement;
    public GameObject medKitPrefab;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        navMeshAgent = GetComponent<NavMeshAgent>();
        this.bossStatus = GetComponent<Status>();
        this.animationController = GetComponent<AnimationController>();
        this.movement = GetComponent<Movement>();
        this.navMeshAgent.speed = bossStatus.velocity;
    }

    private void Update()
    {
        this.navMeshAgent.SetDestination(this.player.transform.position);
        this.animationController.Walk(this.navMeshAgent.velocity.magnitude);
        Vector3 direction = player.transform.position - transform.position;
        this.movement.LookRotation(direction);

        if (this.navMeshAgent.hasPath)
        {
            bool IsClose = this.navMeshAgent.remainingDistance <= this.navMeshAgent.stoppingDistance;
            if (IsClose)
            {
                this.animationController.ZombieAtk(true);                
            }
            else
            {
                this.animationController.ZombieAtk(false);
            }
        }
    }

    void Damage()
    {
        this.player.GetComponent<ControlaJogador>().TakeDamage(Random.Range(30, 41));
    }

    public void TakeDamage(int damageValue)
    {
        this.bossStatus.Life -= damageValue;
        if(this.bossStatus.Life <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        this.animationController.ZombieDeath();
        this.movement.Death();
        this.enabled = false;
        this.navMeshAgent.enabled = false;
        Instantiate(medKitPrefab, transform.position, Quaternion.identity);
        Destroy(this, 2);
    }
}
