using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlaMenu : MonoBehaviour {

    public GameObject BotaoSair;

    private void Start()
    {
        #if UNITY_STANDALONE || UNITY_EDITOR
            BotaoSair.SetActive(true);
        #endif
    }

    public void JogarJogo()
    {
        StartCoroutine(MudarCena("Hotel"));
    }

    public void SairJogo()
    {
        StartCoroutine(Sair());
    }

    IEnumerator MudarCena(string nomeCena)
    {
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene(nomeCena);
    }

    IEnumerator Sair()
    {
        yield return new WaitForSeconds(0.3f);
        Application.Quit();
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
