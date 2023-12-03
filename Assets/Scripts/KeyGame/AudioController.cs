using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioSource musicaDeFundo;
    public AudioSource musicaVoceGanhou;
    public AudioSource searchingSoundFX;
    public AudioSource runningSound;
    public AudioClip[] musicas;

    void Start()
    {
        AudioClip musicaLoop = musicas[0];
        musicaDeFundo.clip = musicaLoop;
        musicaDeFundo.loop = true;
        musicaDeFundo.Play();


        
    }

    public void WIN()
    {
        musicaVoceGanhou.clip = musicas[1];
        musicaVoceGanhou.Play();
        musicaVoceGanhou.loop = false;
        musicaDeFundo.Pause();
    
    }

    public void SearchingSound()
    {
        searchingSoundFX.clip = musicas[2];
        searchingSoundFX.Play();
        searchingSoundFX.loop = false;
        searchingSoundFX.Pause();

    }

    public void RunningSound()
    {
        runningSound.clip = musicas[3];
        runningSound.Play();
        runningSound.loop = false;
        runningSound.Pause();
    }



}
