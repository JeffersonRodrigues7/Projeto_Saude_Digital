using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LifeMoita : MonoBehaviour
{
    
    private Slider slider;
    public bool isSearching;

    void Start()
    {
        slider = gameObject.GetComponentInChildren<Slider>();
    }

    public void UpdateHealthBar(Slider slider)
    {
        if (isSearching)
        {
            slider.value = Mathf.Max(slider.value - 0.5f, -0.1f);
        }
        else
        {
            slider.value = Mathf.Min(slider.value + 0.002f, 1.0f);
        }
        
    }

    void Update()
    {
        UpdateHealthBar(slider);

        isSearching = false;
    }

    public void Searching()
    {
        isSearching = true;
    }



    

    //public void achouChave(string moita)
    //{
    //    if (moita == "moitaComChave")
    /*  {
            score++;
            updateScore();
            audioController.WIN(voceAchouChave);

            WIN.SetActive(true);

            Debug.Log("-----------------VOCE ACHOU A CHAVE ----------------------");
        }
    }*/
}
