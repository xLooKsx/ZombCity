using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed = 30;

    private Rigidbody rigidbody;

    private void Start()
    {
        this.rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        this.rigidbody.MovePosition(this.rigidbody.position + this.transform.forward * speed * Time.deltaTime);
    }
}
