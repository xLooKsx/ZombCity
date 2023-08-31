using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour {

    public int MaxLife = 100;

     public int Life;

    public float velocity = 5;

    private void Awake()
    {
        this.Life = MaxLife;
    }

    public bool IsLifeComplete()
    {
        return this.Life == this.MaxLife;
    }

    public int DamageSuffered() {

        return this.Life - this.MaxLife;
    }

    public void SetAmountToHeal(int maxHealthRegeneration)
    {
        int totalToHeal = 0;
        int totalLifeAfterHeal = this.Life + maxHealthRegeneration;

        if(totalLifeAfterHeal > this.MaxLife)
        {
            int mod = totalLifeAfterHeal - this.MaxLife;
            totalToHeal = maxHealthRegeneration - mod;
        }
        else
        {
            totalToHeal = maxHealthRegeneration;
        }

        this.Life += totalToHeal;
    }
}
