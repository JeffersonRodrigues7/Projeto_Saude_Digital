using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Dicas : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject dica02;
    public GameObject dica03;
    public GameObject dica04;
    public GameObject dica05;
    public GameObject atencaoUltimaDica;
    public bool certezaUltimaDica;
    int ultimaDicaAtiva = 1;

    void Start()
    {
        certezaUltimaDica = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void proximaDica(bool certeza)
    {
        if (ultimaDicaAtiva <= 4)
        {
            ultimaDicaAtiva += 1;
            ativaDica();
        }
        else
        {
            atencaoUltimaDica.SetActive(true);
        }


        
    }

    public void ativaDica()
    {
        switch (ultimaDicaAtiva)
        {
            case 2:
                dica02.SetActive(true);
                break;

            case 3:
                dica03.SetActive(true);
                break;

            case 4:
                dica04.SetActive(true);
                break;

        }



    }

    public void Resposta()
    {
        dica05.SetActive(true);
        atencaoUltimaDica.SetActive(false);

    }

    public void naoCerteza()
    {
        gameObject.SetActive(true);
        atencaoUltimaDica.SetActive(false);
    }
}
