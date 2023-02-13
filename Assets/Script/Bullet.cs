using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float Speed = 30;
    public AudioClip ZombieHitSound;

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
            Destroy(objetoDeColisao.gameObject);
            //ControlaAudio.Instance.PlayOneShot(ZombieHitSound);
        }
        Destroy(this.gameObject);
    }
}
