using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaCamera : MonoBehaviour {

    public GameObject player;

    private Vector3 distance;

	// Use this for initialization
	void Start () {

        this.distance = this.transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        this.transform.position = player.transform.position + distance;
	}
}
