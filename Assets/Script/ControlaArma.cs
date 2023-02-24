using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaArma : MonoBehaviour {

    public GameObject Bullet;
    public GameObject WeaponBulletRespawn;
    public AudioClip shootSound;
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetButtonDown("Fire1"))
        {
            ControlaAudio.Instance.PlayOneShot(this.shootSound);
            Instantiate(Bullet, WeaponBulletRespawn.transform.position, WeaponBulletRespawn.transform.rotation);
        }        
	}
}
