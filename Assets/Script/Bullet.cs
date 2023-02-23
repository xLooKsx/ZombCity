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
        if (objetoDeColisao.tag == "Inimigo")
        {
            objetoDeColisao.GetComponent<ControlaZumbi>().TakeDamage(damage);
            
        }
        Destroy(this.gameObject);
    }
}
