using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawn : MonoBehaviour {

    public GameObject bossPrefab;
    public float timeBetweenEachSpawn = 60;
    public ControlaInterface scriptControlaInterface;
    public Transform[] PosicoesPossiveisDeGeracao;

    private Transform jogador;
    private float timeToNextSpawn = 0;

    private void Start()
    {
        timeToNextSpawn = timeBetweenEachSpawn;
        scriptControlaInterface = GameObject.FindObjectOfType(typeof(ControlaInterface)) as ControlaInterface;
        jogador = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        if(Time.timeSinceLevelLoad > timeToNextSpawn)
        {
            Vector3 posicaoCriacao = CalcularPosicaoMaisDistante();
            Instantiate(bossPrefab, posicaoCriacao, Quaternion.identity);
            scriptControlaInterface.AparecerTextoChefeCriado();
            timeToNextSpawn = Time.timeSinceLevelLoad + timeBetweenEachSpawn;
        }
    }

    Vector3 CalcularPosicaoMaisDistante()
    {
        Vector3 posicaoDeMaiorDistancia = Vector3.zero;

        float maiorDistancia = 0;
        foreach (Transform posicao in PosicoesPossiveisDeGeracao)
        {
            float distanciaEntreOJogador = Vector3.Distance(posicao.position, jogador.position);
            if(distanciaEntreOJogador > maiorDistancia)
            {
                maiorDistancia = distanciaEntreOJogador;
                posicaoDeMaiorDistancia = posicao.position;
            }
        }

        return posicaoDeMaiorDistancia;
    }
}
