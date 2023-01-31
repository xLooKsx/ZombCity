using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComtrolaZumbi : MonoBehaviour {

    public float speed = 5;
    public GameObject player;


    private Rigidbody rigidbody;

	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {       
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if(distance >= 2.5)
        {
            Vector3 direction = player.transform.position - transform.position;
            this.rigidbody.MovePosition(this.rigidbody.position + (direction.normalized * speed * Time.deltaTime));

            Quaternion rotation = Quaternion.LookRotation(direction);
            this.rigidbody.MoveRotation(rotation);
        }

        
    }
}
