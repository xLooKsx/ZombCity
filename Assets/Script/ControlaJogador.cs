using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaJogador : MonoBehaviour, IDamage {
    
    public LayerMask LayerMask;
    public GameObject GameOverText;
    public ControlaInterface ScriptControlaInterface;
    public AudioClip DamageSound;
    [HideInInspector] public Status Status;

    private Vector3 movimentacao;
    private PlayerMovement movement;
    private AnimationController animationController;
    
    private void Start()
    {
        this.movement = GetComponent<PlayerMovement>();
        this.animationController = GetComponent<AnimationController>();
        this.Status = GetComponent<Status>();
    }

    // Update is called once per frame
    void Update () {

        float eixoX = Input.GetAxis("Horizontal");
        float eixoZ = Input.GetAxis("Vertical");

        this.movimentacao = new Vector3(eixoX, 0, eixoZ);
        this.animationController.Walk(this.movimentacao.magnitude);
	}

    private void FixedUpdate()
    {
        this.movement.Move(this.movimentacao, this.Status.velocity);
        this.movement.LookAround(LayerMask);

    }

    public void TakeDamage(int damageValue)
    {
        this.Status.Life -= damageValue;
        this.ScriptControlaInterface.UpdateSlideHealthbar();
        ControlaAudio.Instance.PlayOneShot(this.DamageSound);
        if (this.Status.Life <= 0)
        {
            this.Die();
        }
           
    }

    public void RecieveHeal(int amount)
    {
        this.Status.SetAmountToHeal(amount);
        this.ScriptControlaInterface.UpdateSlideHealthbar();
    }

    public void Die()
    {
        this.ScriptControlaInterface.GameOver();
    }
}
