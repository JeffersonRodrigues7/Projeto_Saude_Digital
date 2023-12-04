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

        musicaVoceGanhou.clip = musicas[1];
        searchingSoundFX.clip = musicas[2];
        runningSound.clip = musicas[3];




    }

    public void WIN()
    {
        
        musicaVoceGanhou.Play();
        musicaVoceGanhou.loop = false;
        musicaDeFundo.Pause();
    
    }

    public void SearchingSound()
    {
        
        searchingSoundFX.Play();
        searchingSoundFX.loop = false;
        searchingSoundFX.Pause();

    }

    public void RunningSound()
    {
        
        runningSound.Play();
        runningSound.loop = false;
        runningSound.Pause();
    }



}
