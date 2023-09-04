using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawn : MonoBehaviour {

    public GameObject bossPrefab;
    public float timeBetweenEachSpawn = 60;
    public ControlaInterface scriptControlaInterface;

    private float timeToNextSpawn = 0;

    private void Start()
    {
        timeToNextSpawn = timeBetweenEachSpawn;
        scriptControlaInterface = GameObject.FindObjectOfType(typeof(ControlaInterface)) as ControlaInterface;
    }

    private void Update()
    {
        if(Time.timeSinceLevelLoad > timeToNextSpawn)
        {
            Instantiate(bossPrefab, transform.position, Quaternion.identity);
            scriptControlaInterface.AparecerTextoChefeCriado();
            timeToNextSpawn = Time.timeSinceLevelLoad + timeBetweenEachSpawn;
        }
    }
}
