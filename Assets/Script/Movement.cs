using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    private Rigidbody rigidbody;
    private AnimationController animationController;

    private void Awake()
    {
        this.rigidbody = GetComponent<Rigidbody>();
        this.animationController = GetComponent<AnimationController>();
    }

    public void Move(Vector3 direction, float speed)
    {
        LookRotation(direction);
        this.animationController.Walk(1);
        this.rigidbody.MovePosition(this.rigidbody.position + direction.normalized * speed * Time.deltaTime);
    }

    protected void LookRotation(Vector3 direction)
    {
        if(direction != Vector3.zero) { 
            Quaternion rotation = Quaternion.LookRotation(direction);
            this.rigidbody.MoveRotation(rotation);
        }
    }
}
