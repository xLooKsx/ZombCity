using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawn : MonoBehaviour {

    public GameObject zombie;
    public float zombieSpawnTime = 1;

    private float timeCount = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        timeCount += Time.deltaTime;

        if(timeCount >= zombieSpawnTime) {
            Instantiate(zombie, transform.position, transform.rotation);
            timeCount = 0;
        }

        
	}
}
