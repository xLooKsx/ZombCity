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

    private Animator animator;
    private Vector3 movimentacao;
    private Movement movement;

    private void Start()
    {
        Time.timeScale = 1;
        this.animator = GetComponent<Animator>();
        this.movement = GetComponent<Movement>();
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
        
        if(movimentacao != Vector3.zero)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
	}

    private void FixedUpdate()
    {

        movement.Move(movimentacao, Speed);
        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(raio.origin, raio.direction * 100, Color.red);

        RaycastHit impacto;
        if(Physics.Raycast(raio, out impacto, 100, LayerMask))
        {
            Vector3 playerAim = impacto.point - transform.position;
            playerAim.y = transform.position.y;
            
            this.movement.LookRotation(playerAim);
        }
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
