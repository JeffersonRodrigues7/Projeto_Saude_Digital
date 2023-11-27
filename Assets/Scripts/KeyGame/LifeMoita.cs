using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LifeMoita : MonoBehaviour
{
    
    private Slider slider;
    public bool isSearching;
    public Button buttonSearching;
    public KeyGamePlayer playerSearching;

    void Start()
    {
        slider = gameObject.GetComponentInChildren<Slider>();
    }

    public void UpdateHealthBar(Slider slider)
    {
        if (isSearching)
        {
            slider.value = Mathf.Max(slider.value - 0.1f, -0.1f);
        }
        else
        {
            slider.value = Mathf.Min(slider.value + 0.002f, 1.0f);
        }
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        buttonSearching.onClick.AddListener(Searching);

        if (collision.gameObject.CompareTag("Player") && isSearching)
        {
            UpdateHealthBar(slider);
        }

        isSearching = false;
    }

    

    void Update()
    {
        UpdateHealthBar(slider);
        if (slider.value <= 0f)
        {
            if (!playerSearching.achouChave(gameObject.name))
            {
                Destroy(gameObject);
            }
            
        }
    }

    


    public void Searching()
    {
        isSearching = true;
    }



    

    
}
