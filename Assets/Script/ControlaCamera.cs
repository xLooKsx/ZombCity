using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaCamera : MonoBehaviour {

    public GameObject Player;

    private Vector3 distance;

	// Use this for initialization
	void Start () {

        this.distance = this.transform.position - Player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        this.transform.position = Player.transform.position + distance;
	}
}
