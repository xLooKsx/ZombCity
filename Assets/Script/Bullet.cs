using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float Speed = 30;

    private readonly int damage = 50;
    private Rigidbody rigidbody;

    private void Start()
    {
        this.rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        this.rigidbody.MovePosition(this.rigidbody.position + this.transform.forward * Speed * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider objetoDeColisao)
    {
        Quaternion rotacaoOpostABala = Quaternion.LookRotation(-transform.forward);
        switch (objetoDeColisao.tag)
        {        
            case "Inimigo":
                ControlaZumbi controlaZumbi = objetoDeColisao.GetComponent<ControlaZumbi>();
                controlaZumbi.TakeDamage(damage);
                controlaZumbi.ParticulaSangue(transform.position, rotacaoOpostABala);
                break;
            case "boss":
                BossController bossController = objetoDeColisao.GetComponent<BossController>();
                bossController.TakeDamage(damage);
                bossController.ParticulaSangue(transform.position, rotacaoOpostABala);
                break;
        }
        Destroy(this.gameObject);
    }
}
