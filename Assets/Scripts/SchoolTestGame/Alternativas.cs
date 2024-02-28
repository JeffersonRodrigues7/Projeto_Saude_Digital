using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Alternativas : MonoBehaviour
{
    public List<string> alternativas;
    public List<string> questoes;

    public BoolVariable jogadorErrou;
    public BoolVariable imaginacao_respiracao_ofegante;

    private Vector3 posInicial1;
    private Vector3 posInicial2;
    private float canvasHeight;
    public float velocidade;
    private int numQuestao = 0;
    public bool isPaused = false;
    private List<bool> lembrancas = new List<bool>();
    public GameObject conversas_alan;

    private GameObject alternativa1;
    private GameObject alternativa2;
    private GameObject questao;

    private GameObject cenaRespiracaoOfegante;


    Dictionary<int, int> corretas = new Dictionary<int, int>();

    private void Start()
    {
        jogadorErrou.Value = false;
        // Obt�m a altura do canvas onde a resposta � exibida
        alternativa1 = GameObject.Find("Alternativa_1");
        alternativa2 = GameObject.Find("Alternativa_2");

        

        questao = gameObject;

        posInicial1 = alternativa1.transform.position;
        posInicial2 = alternativa2.transform.position;

        lembrancas.Add(false);
        lembrancas.Add(false);
        lembrancas.Add(false);
        lembrancas.Add(false);
        lembrancas.Add(false);

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

        if (numQuestao == 3 && lembrancas[0] == false)
        {
            imaginacao_respiracao_ofegante.Value = true;
            conversas_alan.SetActive(true);
            PauseGame();
        }

        /*Debug.Log(verificaQueda(alternativa1.transform.position.y) + alternativa1.transform.position.y.ToString());*/

        
        if (verificaQueda(alternativa1.transform.position.y) && numQuestao < 10)
        {
            jogadorErrou.Value = true;
            conversas_alan.SetActive(true);
            PauseGame();

            
            atualiza(jogadorErrou);
        }

    }

    private void atualiza(BoolVariable errou)
    {
        if (errou.Value == false) { 
            numQuestao++;
            Debug.Log(numQuestao);
            atualizaAlternativa(numQuestao);
            atualizaQuestao(numQuestao);
        }
        else
        {
            Debug.Log(numQuestao);
            atualizaAlternativa(numQuestao);
            atualizaQuestao(numQuestao);
        }
    }

    private bool validaResposta(int numAlternativa)
    {
        if (corretas[numQuestao] == numAlternativa)
        {
            Debug.Log("resposta correta!!");
            jogadorErrou.Value = false;
            atualiza(jogadorErrou);
            return true;
        }
        else
        {
            Debug.Log("resposta errada!!");

            jogadorErrou.Value = true;
            conversas_alan.SetActive(true);
            PauseGame();

            
            atualiza(jogadorErrou);
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

    public void PauseGame()
    {
        alternativa1.transform.Translate(Vector3.down * 0 * Time.deltaTime);
        alternativa2.transform.Translate(Vector3.down * 0 * Time.deltaTime);// Pausa o jogo
        isPaused = true;
        // Aqui você pode adicionar código adicional, como mostrar um menu de pausa
    }

    public void ResumeGame()
    {
        alternativa1.transform.Translate(Vector3.down * velocidade * Time.deltaTime);
        alternativa2.transform.Translate(Vector3.down * velocidade * Time.deltaTime); // Continua o jogo com o tempo normal
        isPaused = false;
        jogadorErrou.Value = false;

        if (numQuestao == 3)
        {
            lembrancas[0] = true;
        }
        
        // Aqui você pode adicionar código adicional, como esconder o menu de pausa
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
