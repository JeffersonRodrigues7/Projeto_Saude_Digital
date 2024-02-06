using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioClip audio_relogio;
    public AudioClip audio_tensao;
    public AudioClip audio_respiracao_ofegante;
    public AudioClip audio_respirando_fundo;

    public AudioSource SFXSource;
    public AudioSource BackgoundMusic;


    void Start()
    {
        BackgoundMusic.clip = audio_relogio;
        
        BackgoundMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
