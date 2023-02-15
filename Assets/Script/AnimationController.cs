using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {

    private Animator animator;

    // Use this for initialization
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
}
