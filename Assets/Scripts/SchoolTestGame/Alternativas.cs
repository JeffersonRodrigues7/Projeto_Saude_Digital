using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Alternativas : MonoBehaviour
{
    public List<string> alternativas;
    public List<string> questoes;

    private Vector3 posInicial1;
    private Vector3 posInicial2;
    private float canvasHeight;
    private float velocidade = 0.7f;

    private GameObject alternativa1;
    private GameObject alternativa2;
    private GameObject questao;


    private void atualizaAlternativa(int i)
    {
        if (i == 0) {
            alternativa1.GetComponentInChildren<Text>().text = alternativas[i];
            alternativa2.GetComponentInChildren<Text>().text = alternativas[i + 1];
        }
        else
        {
            alternativa1.GetComponentInChildren<Text>().text = alternativas[i + 1];
            alternativa2.GetComponentInChildren<Text>().text = alternativas[i + 2];
        }

        alternativa1.transform.position = posInicial1;
        alternativa2.transform.position = posInicial2;
    }

    private void atualizaQuestao (int i)
    {
        questao.GetComponentInChildren<Text>().text = questoes[i];
    }

    private void Start()
    {
        // Obt�m a altura do canvas onde a resposta � exibida
        alternativa1 = GameObject.Find("Alternativa_1");
        alternativa2 = GameObject.Find("Alternativa_2");

        questao = gameObject;

        posInicial1 = alternativa1.transform.position;
        posInicial2 = alternativa2.transform.position;

        atualizaAlternativa(0);
        atualizaQuestao(0);


    }

    // Update is called once per frame
    void Update()
    {
        alternativa1.transform.Translate(Vector3.down * velocidade * Time.deltaTime);
        alternativa2.transform.Translate(Vector3.down * velocidade * Time.deltaTime);

        Debug.Log(verificaQueda(alternativa1.transform.position.y) + alternativa1.transform.position.y.ToString());

        if (verificaQueda(alternativa1.transform.position.y))
        {
            atualizaAlternativa(1);
            atualizaQuestao(1);
        }

        
    }

    bool verificaQueda(float posY)
    {
        if (posY < -5f)
        {
            return true;
        }else
        {
            return false;
        }
    }
}
