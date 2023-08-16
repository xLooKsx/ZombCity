using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawn : MonoBehaviour {

    private float timeToNextSpawn = 0;
    public GameObject bossPrefab;
    public float timeBetweenEachSpawn = 60;

    private void Start()
    {
        timeToNextSpawn = timeBetweenEachSpawn;
    }

    private void Update()
    {
        if(Time.timeSinceLevelLoad > timeToNextSpawn)
        {
            Instantiate(bossPrefab, transform.position, Quaternion.identity);
            timeToNextSpawn = Time.timeSinceLevelLoad + timeBetweenEachSpawn;
        }
    }
}
