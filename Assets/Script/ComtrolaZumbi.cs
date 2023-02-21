using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComtrolaZumbi : MonoBehaviour, IDamage{

    public AudioClip ZombieHitSound;

    private int zombieType;
    private GameObject player;
    private Movement movement;
    private AnimationController animationController;
    private Status status;
    private Vector3 randomPosition;
    private Vector3 myPosition;
    private float walkAroundCounter;
    private readonly float timeBetweenDirectionChange = 4;
    private readonly int zombieWalkAroundRadius = 10;


    // Use this for initialization
    void Start () {

        this.player = GameObject.FindWithTag("Player");        
        this.movement = GetComponent<Movement>();
        this.animationController = GetComponent<AnimationController>();
        this.status = GetComponent<Status>();
        generateAnRandomZombieSkin();
    }

    private void FixedUpdate()
    {       
        float distance = Vector3.Distance(player.transform.position, transform.position);
        

        if(distance > 14)
        {
            WalkAround();
        }
        else if (distance > 7)
        {
            chaseAfterPlayer();
        }
        else
        {
            this.animationController.ZombieAtk(true);
        }        
    }

    private void chaseAfterPlayer()
    {
        this.myPosition = player.transform.position - transform.position;
        movement.Move(myPosition, this.status.velocity);
        this.animationController.ZombieAtk(false);
    }

    private void WalkAround()
    {
        this.walkAroundCounter -= Time.deltaTime;
        if(this.walkAroundCounter <= 0)
        {
            this.randomPosition = GenerateRandomPosition();
            this.walkAroundCounter += this.timeBetweenDirectionChange;
        }

        bool isCloseEnough = Vector3.Distance(transform.position, this.randomPosition) <= 0.5;
        if (!isCloseEnough)
        {
            this.myPosition = this.randomPosition - transform.position;
            movement.Move(myPosition, this.status.velocity);
            this.animationController.Walk(1);
        }
        else
        {
           this.animationController.Walk(0);
        }
       

    }

    void generateAnRandomZombieSkin()
    {
        zombieType = Random.Range(1, 28);
        transform.GetChild(zombieType).gameObject.SetActive(true);
    }

    void Damage()
    {
        this.player.GetComponent<ControlaJogador>().TakeDamage(Random.Range(20, 31));
    }

    public void TakeDamage(int damageValue)
    {
        this.status.Life -= damageValue;
        ControlaAudio.Instance.PlayOneShot(ZombieHitSound);
        if (this.status.Life <= 0)
        {
            this.Die();
        }
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }

    private Vector3 GenerateRandomPosition()
    {
        Vector3 position = Random.insideUnitSphere * this.zombieWalkAroundRadius;
        position += transform.position;
        position.y = 0;

        return position;
    }
}
