using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaAudio : MonoBehaviour {

    public static AudioSource Instance;

    private AudioSource audioSource;

    private void Awake()
    {
        this.audioSource = GetComponent<AudioSource>();
        Instance = this.audioSource;
    }
}
