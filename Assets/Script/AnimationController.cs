using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {

    private Animator animator;

    void Start () {
        this.animator = GetComponent<Animator>();
    }

    public void ZombieAtk(bool attack)
    {
        this.animator.SetBool("Attack", attack);
    }
	
	public void Walk(float value)
    {
        animator.SetFloat("isRunning", value);
    }

    public void ZombieDeath(){
        animator.SetTrigger("dead");
    }
}
