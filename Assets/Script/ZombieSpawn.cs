using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawn : MonoBehaviour {

    public GameObject Zombie;
    public float ZombieSpawnTime = 1;
    public LayerMask LayerMask;

    private float timeCount = 0;
    private GameObject player;
    private int quantityOfZombiesAlive = 0;
    private float currentLevelInSeconds = 0;
    private int maxQuantityOfZombiesAlive = 2;    

    private readonly float zombieRadiusSpawn = 3;
    private readonly float definedDistanceFromThePlayer = 20;
    private readonly float nextLevelInSeconds = 10;
    

    private void Start()
    {
        this.player = GameObject.FindWithTag("Player");
        GenerateStarterZombies();
        currentLevelInSeconds = nextLevelInSeconds;
    }

    private void GenerateStarterZombies()
    {
        for(int i= 0; i< this.maxQuantityOfZombiesAlive; i++)
        {
            StartCoroutine(GenerateANewZombie());
        }
    }

    // Update is called once per frame
    void Update () {

        float distanceFromThePlayer = Vector3.Distance(transform.position, this.player.transform.position);
        bool isPLayerDistanteFromThisSpawn = distanceFromThePlayer > this.definedDistanceFromThePlayer;
        bool canSpawnZombies = this.quantityOfZombiesAlive < this.maxQuantityOfZombiesAlive;

        if (isPLayerDistanteFromThisSpawn && canSpawnZombies)
        {
            timeCount += Time.deltaTime;

            if (timeCount >= ZombieSpawnTime)
            {

                StartCoroutine(GenerateANewZombie());
                timeCount = 0;
            }
        }

        if(Time.timeSinceLevelLoad > this.currentLevelInSeconds)
        {
            maxQuantityOfZombiesAlive ++;
            this.currentLevelInSeconds += this.nextLevelInSeconds;
        }
             
	}

    IEnumerator GenerateANewZombie()
    {
        Vector3 randomPosition;
        do
        {
            randomPosition = RandomPosition();
            yield return null;

        } while (!IsRandomPositionGood(randomPosition));

        ControlaZumbi controlaZumbi = Instantiate(Zombie, randomPosition, transform.rotation).GetComponent<ControlaZumbi>();
        controlaZumbi.ZombieSpawn = this;
        this.quantityOfZombiesAlive++;
    }

    bool IsRandomPositionGood(Vector3 randomPosition)
    {
        Collider[] colliders = Physics.OverlapSphere(randomPosition, 1, LayerMask);
        return colliders.Length == 0;
    }

    Vector3 RandomPosition()
    {
        Vector3 position = Random.insideUnitSphere * zombieRadiusSpawn;
        position += transform.position;
        position.y = 0;
        return position;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, zombieRadiusSpawn);
             
    }

    public void AnnounceZombieDeath()
    {
        this.quantityOfZombiesAlive--;
    }
}
