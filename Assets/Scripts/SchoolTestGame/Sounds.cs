using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioClip audio_relogio;
    public AudioClip audio_background;
    public AudioClip audio_tensao;
    public AudioClip audio_respiracao_ofegante;
    public AudioClip audio_respirando_fundo;

    public AudioSource SFXSource;
    public AudioSource BackgoundMusic;


    void Start()
    {
        BackgoundMusic.clip = audio_background;
        BackgoundMusic.Play();

        SFXSource.clip = audio_relogio;
        SFXSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAudioTensao()
    {
        BackgoundMusic.clip = audio_tensao;

        BackgoundMusic.Play();
    }

    public void PlayAudioRespiracaoOfegante()
    {
        BackgoundMusic.clip = audio_respiracao_ofegante;

        BackgoundMusic.Play();
    }
}
