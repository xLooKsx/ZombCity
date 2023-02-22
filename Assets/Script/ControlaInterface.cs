using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlaInterface : MonoBehaviour {

    public Slider SliderHealthbar;
    public GameObject GameOverPanel;
    public Text SurvivingText;

    private ControlaJogador scriptControlaJogador;    
    private readonly string initialSurvivingText = "Você Sobreviveu por ";

    // Use this for initialization
    void Start () {
        scriptControlaJogador = GameObject.FindWithTag("Player").GetComponent<ControlaJogador>();

        this.SliderHealthbar.maxValue = this.scriptControlaJogador.Status.Life;
        this.UpdateSlideHealthbar();
        Time.timeScale = 1;
    }

    public void UpdateSlideHealthbar()
    {
        this.SliderHealthbar.value = scriptControlaJogador.Status.Life;
    }

    public void GameOver()
    {
        this.GameOverPanel.SetActive(true);
        Time.timeScale = 0;

        int minutes = (int)Time.timeSinceLevelLoad / 60;
        int seconds = (int)Time.timeSinceLevelLoad % 60;

        this.SurvivingText.text = initialSurvivingText + minutes + " min e "+seconds+"s";    
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene("Hotel");
    }
}
