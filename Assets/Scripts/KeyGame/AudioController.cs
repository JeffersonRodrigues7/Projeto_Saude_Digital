using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioSource musicaDeFundo;
    public AudioSource musicaVoceGanhou;
    public AudioClip[] musicas;

    void Start()
    {
        AudioClip musicaLoop = musicas[0];
        musicaDeFundo.clip = musicaLoop;
        musicaDeFundo.loop = true;
        musicaDeFundo.Play();


        
    }

    public void WIN (AudioClip clip)
    {
        musicaVoceGanhou.clip = clip;
        musicaVoceGanhou.Play();
        musicaVoceGanhou.loop = false;
        musicaDeFundo.Pause();
    
    }



}
