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
        Vector3 direction = player.transform.position - transform.position;
        this.movement.LookRotation(direction);

        if (distance > 2.5)
        {
            movement.Move(direction, this.status.velocity);
            this.animationController.ZombieAtk(false);
        }
        else
        {
            this.animationController.ZombieAtk(true);
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
}
