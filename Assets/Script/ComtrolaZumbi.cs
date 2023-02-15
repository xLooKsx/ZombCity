using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComtrolaZumbi : MonoBehaviour {

    public float Speed = 5;

    private int zombieType;
    private GameObject player;
    private Animator animator;
    private Movement movement;

	// Use this for initialization
	void Start () {

        this.player = GameObject.FindWithTag("Player");
        this.animator = GetComponent<Animator>();
        this.movement = GetComponent<Movement>();

        zombieType = Random.Range(1, 28);
        transform.GetChild(zombieType).gameObject.SetActive(true);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {       
        float distance = Vector3.Distance(player.transform.position, transform.position);
        Vector3 direction = player.transform.position - transform.position;
        this.movement.LookRotation(direction);

        if (distance > 2.5)
        {
            movement.Move(direction, Speed);
            this.animator.SetBool("Attack", false);
        }
        else
        {
            this.animator.SetBool("Attack", true);
        }        
    }

    void Damage()
    {
        this.player.GetComponent<ControlaJogador>().RecieveDamage(Random.Range(20, 31));
    }
}
