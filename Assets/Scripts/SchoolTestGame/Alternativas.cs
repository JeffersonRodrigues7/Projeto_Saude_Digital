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
    public float velocidade;
    private int numQuestao = 0;

    private GameObject alternativa1;
    private GameObject alternativa2;
    private GameObject questao;

    private Sounds sounds;
    private int[] corretas = { 1, 2, 5, 6 };

    private void Start()
    {
        // Obt�m a altura do canvas onde a resposta � exibida
        alternativa1 = GameObject.Find("Alternativa_1");
        alternativa2 = GameObject.Find("Alternativa_2");

        questao = gameObject;

        posInicial1 = alternativa1.transform.position;
        posInicial2 = alternativa2.transform.position;

        atualizaAlternativa(numQuestao);
        atualizaQuestao(numQuestao);


    }

    // Update is called once per frame
    void Update()
    {
        alternativa1.transform.Translate(Vector3.down * velocidade * Time.deltaTime);
        alternativa2.transform.Translate(Vector3.down * velocidade * Time.deltaTime);

        Debug.Log(verificaQueda(alternativa1.transform.position.y) + alternativa1.transform.position.y.ToString());

        
        if (verificaQueda(alternativa1.transform.position.y) && numQuestao < 5)
        {
            numQuestao++;
            atualizaAlternativa(numQuestao);
            atualizaQuestao(numQuestao);   
        }

        /*alternativa1.GetComponent<Button>().onClick.AddListener();*/
        /*alternativa2.GetComponent<Button>().onClick.AddListener();*/


    }

    private void alternativaSelecionada(int i)
    {
        /*if (alternativaCorreta(i)) {
            sounds.PlayAudioTensao();
        }else
        {
            sounds.PlayAudioRespiracaoOfegante();
        }*/
    }

    private void atualizaAlternativa(int i)
    {
        alternativa1.GetComponentInChildren<Text>().text = alternativas[i * 2];
        alternativa2.GetComponentInChildren<Text>().text = alternativas[(i * 2) + 1];



        alternativa1.transform.position = posInicial1;
        alternativa2.transform.position = posInicial2;
    }

    private void atualizaQuestao(int i)
    {
        questao.GetComponentInChildren<Text>().text = questoes[i];
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
