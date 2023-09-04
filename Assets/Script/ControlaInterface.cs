using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlaInterface : MonoBehaviour {

    public Slider SliderHealthbar;
    public GameObject GameOverPanel;
    public Text SurvivingText;
    public Text BestSurvivingTimeText;
    public Text TextQuantityZombiesKilled;
    public Text TextoChefeAparece;

    private ControlaJogador scriptControlaJogador;
    private float bestSurvivingTime;
    private int minutes = 0;
    private int seconds = 0;
    private int zombiesKilled = 0;
    private readonly string initialSurvivingText = "Você Sobreviveu por {0}min e {1}s";
    private readonly string bestSurvivingText = "Melhor Tempo {0}min e {1}s";    

    // Use this for initialization
    void Start () {
        scriptControlaJogador = GameObject.FindWithTag("Player").GetComponent<ControlaJogador>();

        this.SliderHealthbar.maxValue = this.scriptControlaJogador.Status.Life;
        this.UpdateSlideHealthbar();
        Time.timeScale = 1;
        this.bestSurvivingTime = PlayerPrefs.GetFloat("HiScore");
        UpdateZombiesKilledText(this.zombiesKilled);
    }

    public void UpdateSlideHealthbar()
    {
        this.SliderHealthbar.value = scriptControlaJogador.Status.Life;
    }

    public void GameOver()
    {
        this.GameOverPanel.SetActive(true);
        Time.timeScale = 0;
        
        GetMinuteAndSecond(Time.timeSinceLevelLoad);
        this.SurvivingText.text = string.Format(initialSurvivingText, minutes, seconds);

        CheckHiScore();        
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene("Hotel");
    }

    void CheckHiScore()
    {
        if(Time.timeSinceLevelLoad > this.bestSurvivingTime)
        {            
            PlayerPrefs.SetFloat("HiScore", Time.timeSinceLevelLoad);
            this.bestSurvivingTime = Time.timeSinceLevelLoad;
        }
        GetMinuteAndSecond(this.bestSurvivingTime);
        this.BestSurvivingTimeText.text = string.Format(bestSurvivingText, minutes, seconds);
    }

    void GetMinuteAndSecond(float time)
    {
       this.minutes = (int)time / 60;
        this.seconds = (int)time % 60;
    }

    public void UpdateZombiesKilled()
    {
        UpdateZombiesKilledText(this.zombiesKilled++);
        
    }

    public void UpdateZombiesKilledText(int quantity)
    {
        this.TextQuantityZombiesKilled.text = string.Format("X {0}", this.zombiesKilled);
    }

    public void AparecerTextoChefeCriado()
    {
        StartCoroutine(DesaparecerTexto(2, TextoChefeAparece));
    }

    IEnumerator DesaparecerTexto(float tempoDeSumico, Text textoParaSumir)
    {
        textoParaSumir.gameObject.SetActive(true);
        Color corTexto = textoParaSumir.color;
        corTexto.a = 1;

        yield return new WaitForSeconds(tempoDeSumico);
        float contador = 0;
        while (textoParaSumir.color.a > 0)
        {
            contador += Time.deltaTime / tempoDeSumico;
            corTexto.a = Mathf.Lerp(1, 0, contador);
            textoParaSumir.color = corTexto;
            if(textoParaSumir.color.a <= 0)
            {
                textoParaSumir.gameObject.SetActive(false);
            }
            yield return null;
        }
    }
}
