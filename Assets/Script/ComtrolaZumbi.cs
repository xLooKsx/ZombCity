﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComtrolaZumbi : MonoBehaviour {

    public float Speed = 5;

    private int kindOfZombie;
    private GameObject player;
    private Rigidbody rigidbody;
    private Animator animator;

	// Use this for initialization
	void Start () {

        this.player = GameObject.FindWithTag("Player");
        this.rigidbody = GetComponent<Rigidbody>();
        this.animator = GetComponent<Animator>();

        kindOfZombie = Random.Range(1, 28);
        transform.GetChild(kindOfZombie).gameObject.SetActive(true);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {       
        float distance = Vector3.Distance(player.transform.position, transform.position);

        Vector3 direction = player.transform.position - transform.position;

        Quaternion rotation = Quaternion.LookRotation(direction);
        this.rigidbody.MoveRotation(rotation);

        if (distance > 2.5)
        {
            this.rigidbody.MovePosition(this.rigidbody.position + direction.normalized * Speed * Time.deltaTime);
            this.animator.SetBool("Attack", false);
        }
        else
        {
            this.animator.SetBool("Attack", true);
        }        
    }

    void Damage()
    {
        Time.timeScale = 0;
        this.player.GetComponent<ControlaJogador>().GameOverText.SetActive(true);
        this.player.GetComponent<ControlaJogador>().IsAlive = false;
    }
}
