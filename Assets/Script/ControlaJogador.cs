using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaJogador : MonoBehaviour {

    public float speed = 10;

    private Animator animator;
    private Vector3 movimentacao;
    private Rigidbody rigidbody;

    private void Start()
    {
        this.animator = GetComponent<Animator>();
        this.rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update () {

        float eixoX = Input.GetAxis("Horizontal");
        float eixoZ = Input.GetAxis("Vertical");

        this.movimentacao = new Vector3(eixoX, 0, eixoZ) * speed * Time.deltaTime;
        
        if(movimentacao != Vector3.zero)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
	}

    private void FixedUpdate()
    {
        this.rigidbody.MovePosition(this.rigidbody.position + movimentacao);
    }
}
