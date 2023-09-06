using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaZumbi : MonoBehaviour, IDamage{

    public AudioClip ZombieHitSound;
    public float distance;
    public GameObject medKitPrefab;
    public GameObject particulaSangue;
    

    private int zombieType;
    private GameObject player;
    private Movement movement;
    private AnimationController animationController;
    private Status status;
    private Vector3 randomPosition;
    private Vector3 myPosition;
    private float walkAroundCounter;
    private ControlaInterface controlaInterface;
    [HideInInspector] public ZombieSpawn ZombieSpawn;

    private readonly float medKitPercentageSpawn = 0.1f;
    private readonly float timeBetweenDirectionChange = 4;
    private readonly int zombieWalkAroundRadius = 10;
    private readonly float distanceFromPlayerToWalkAround = 14;
    private readonly float maxDistanceFromPlayerChaseAfterHim = 13;
    private readonly float minDistanceFromPlayerChaseAfterHim = 2.5f;


    // Use this for initialization
    void Start () {

        this.player = GameObject.FindWithTag("Player");        
        this.movement = GetComponent<Movement>();
        this.animationController = GetComponent<AnimationController>();
        this.status = GetComponent<Status>();
        generateAnRandomZombieSkin();
        controlaInterface = GameObject.FindObjectOfType(typeof(ControlaInterface)) as ControlaInterface;
    }

    private void FixedUpdate()
    {       
        distance = Vector3.Distance(player.transform.position, transform.position);
        

        if(distance >= this.distanceFromPlayerToWalkAround)
        {
            WalkAround();
        }
        else if (distance <= this.maxDistanceFromPlayerChaseAfterHim 
            && distance > this.minDistanceFromPlayerChaseAfterHim)
        {
            ChaseAfterPlayer();
        }
        else if(distance <= this.minDistanceFromPlayerChaseAfterHim)
        {
           this.animationController.ZombieAtk(true);
        }
        else
        {
            this.animationController.ZombieAtk(false);
        }
       
            
    }

    private void ChaseAfterPlayer()
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
            this.walkAroundCounter += this.timeBetweenDirectionChange + Random.Range(-2f, 4f);
        }

        bool isCloseEnough = Vector3.Distance(transform.position, this.randomPosition) <= 0.05;
        if (!isCloseEnough)
        {
            this.myPosition = this.randomPosition - transform.position;
            movement.Move(myPosition, this.status.velocity);
            this.animationController.Walk(1);
        }
        else
        {
            this.myPosition = this.randomPosition - transform.position;
           this.animationController.Walk(0);
        }
        this.animationController.ZombieAtk(false);

    }

    void generateAnRandomZombieSkin()
    {
        zombieType = Random.Range(1, transform.childCount);
        transform.GetChild(zombieType).gameObject.SetActive(true);
    }

    void Damage()
    {
        this.player.GetComponent<ControlaJogador>().TakeDamage(Random.Range(20, 31));
    }

    public void TakeDamage(int damageValue)
    {
        this.status.Life -= damageValue;
        if (this.status.Life <= 0)
        {           
            this.Die();
        }
    }

    public void ParticulaSangue(Vector3 posicao, Quaternion rotacao)
    {
        Instantiate(particulaSangue, posicao, rotacao);
    }

    public void Die()
    {
        Destroy(this.gameObject, 3);
        this.animationController.ZombieDeath();
        this.movement.Death();
        this.enabled = false;
        DropHealthKit();
        ControlaAudio.Instance.PlayOneShot(ZombieHitSound);
        this.controlaInterface.UpdateZombiesKilled();
        this.ZombieSpawn.AnnounceZombieDeath();
        
    }

    private Vector3 GenerateRandomPosition()
    {
        Vector3 position = Random.insideUnitSphere * this.zombieWalkAroundRadius;
        position += transform.position;
        position.y = 0;

        return position;
    }

    void DropHealthKit()
    {
        if(Random.value <= this.medKitPercentageSpawn)
        {
            Instantiate(this.medKitPrefab, this.transform.position, Quaternion.identity);
        }
    }
}
