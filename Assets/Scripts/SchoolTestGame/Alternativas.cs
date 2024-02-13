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

    Dictionary<int, int> corretas = new Dictionary<int, int>();

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

        corretas.Add(0, 1);
        corretas.Add(1, 2);
        corretas.Add(2, 5);
        corretas.Add(3, 6);
        corretas.Add(4, 8);
        corretas.Add(5, 10);
        corretas.Add(6, 11);
        corretas.Add(7, 13);
        corretas.Add(8, 15);
        corretas.Add(9, 17);
        corretas.Add(10, 18);

    }

    // Update is called once per frame
    void Update()
    {
        alternativa1.transform.Translate(Vector3.down * velocidade * Time.deltaTime);
        alternativa2.transform.Translate(Vector3.down * velocidade * Time.deltaTime);

        /*Debug.Log(verificaQueda(alternativa1.transform.position.y) + alternativa1.transform.position.y.ToString());*/

        
        if (verificaQueda(alternativa1.transform.position.y) && numQuestao < 10)
        {
            atualiza();
        }

    }

    private void atualiza()
    {
        numQuestao++;
        Debug.Log(numQuestao);
        atualizaAlternativa(numQuestao);
        atualizaQuestao(numQuestao);
    }

    private bool validaResposta(int numAlternativa)
    {
        if (corretas[numQuestao] == numAlternativa)
        {
            Debug.Log("resposta correta!!");
            atualiza();
            return true;
        }
        else
        {
            Debug.Log("resposta errada!!");
            atualiza();
            return false;
        }
    }

    private void atualizaAlternativa(int i)
    {
        alternativa1.GetComponentInChildren<Text>().text = alternativas[i * 2];
        alternativa2.GetComponentInChildren<Text>().text = alternativas[(i * 2) + 1];

        alternativa1.transform.position = posInicial1;
        alternativa2.transform.position = posInicial2;

        alternativa1.GetComponent<Button>().onClick.RemoveAllListeners();
        alternativa1.GetComponent<Button>().onClick.AddListener(() => validaResposta(i * 2));

        alternativa2.GetComponent<Button>().onClick.RemoveAllListeners();
        alternativa2.GetComponent<Button>().onClick.AddListener(() => validaResposta((i * 2) + 1));
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
