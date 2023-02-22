using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour {

    public int MaxLife = 100;

    [HideInInspector] public int Life;

    public float velocity = 5;

    private void Start()
    {
        this.Life = MaxLife;
    }
}
