using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthKit : MonoBehaviour {

    private readonly int maxHealthRegeneration = 20;
    private int AvailableTime = 5;

    private void Start()
    {
        Destroy(gameObject, this.AvailableTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Heal(other.GetComponent<ControlaJogador>());
            Destroy(this.gameObject);
        }
    }

    void Heal(ControlaJogador player)
    {
        if (!player.Status.IsLifeComplete())
        {
            player.RecieveHeal(maxHealthRegeneration);
        }
    }

    
}
