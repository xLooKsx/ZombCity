using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlaJogador : MonoBehaviour {

    public float Speed = 10;
    public LayerMask LayerMask;
    public GameObject GameOverText;
    public int LifeCount = 100;
    public ControlaInterface ScriptControlaInterface;
    public AudioClip DamageSound;
    
    private Vector3 movimentacao;
    private PlayerMovement movement;
    private AnimationController animationController;

    private void Start()
    {
        Time.timeScale = 1;
        this.movement = GetComponent<PlayerMovement>();
        this.animationController = GetComponent<AnimationController>();
    }

    // Update is called once per frame
    void Update () {

        if (this.LifeCount <=0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                SceneManager.LoadScene("Hotel");
            }
        }

        float eixoX = Input.GetAxis("Horizontal");
        float eixoZ = Input.GetAxis("Vertical");

        this.movimentacao = new Vector3(eixoX, 0, eixoZ);
        this.animationController.Walk(this.movimentacao.magnitude);
	}

    private void FixedUpdate()
    {
        this.movement.Move(this.movimentacao, this.Speed);
        this.movement.LookAround(LayerMask);
       
    }

    public void RecieveDamage(int damage)
    {
        this.LifeCount -= damage;
        this.ScriptControlaInterface.UpdateSlideHealthbar();
        ControlaAudio.Instance.PlayOneShot(this.DamageSound);
        if (this.LifeCount <= 0)
        {
            Time.timeScale = 0;
            this.GameOverText.SetActive(true);
        }        
    }
}
