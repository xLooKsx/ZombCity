using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaArma : MonoBehaviour {

    public GameObject bullet;
    public GameObject weaponBulletRespawn;
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bullet, weaponBulletRespawn.transform.position, weaponBulletRespawn.transform.rotation);
        }        
	}
}
