using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    private Rigidbody rigidbody;

    private void Awake()
    {
        this.rigidbody = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 direction, float speed)
    {
        this.rigidbody.MovePosition(this.rigidbody.position + direction.normalized * speed * Time.deltaTime);
    }

    public void LookRotation(Vector3 direction)
    {
        Quaternion rotation = Quaternion.LookRotation(direction);
        this.rigidbody.MoveRotation(rotation);
    }
}
