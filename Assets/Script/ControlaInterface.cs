using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlaInterface : MonoBehaviour {

    public Slider SliderHealthbar;

    private ControlaJogador scriptControlaJogador;
    
	// Use this for initialization
	void Start () {
        scriptControlaJogador = GameObject.FindWithTag("Player").GetComponent<ControlaJogador>();

        this.SliderHealthbar.maxValue = this.scriptControlaJogador.LifeCount;
        this.UpdateSlideHealthbar();
    }
	
	// Update is called once per frame
	void Update () {
        

    }

    public void UpdateSlideHealthbar()
    {
        this.SliderHealthbar.value = scriptControlaJogador.LifeCount;
    }
}
