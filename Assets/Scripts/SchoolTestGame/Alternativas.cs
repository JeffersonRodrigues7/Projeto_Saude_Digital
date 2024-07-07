using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Alternativas : MonoBehaviour
{
    public List<string> alternativas;
    public List<string> questoes;

    public AudioSource sfxSound;
    public AudioClip acerto_sound;
    public AudioClip erro_sound;


    public BoolVariable jogadorErrou;
    public BoolVariable imaginacao_respiracao_ofegante;

    private Vector3 posInicial1;
    private Vector3 posInicial2;

    public float velocidade;
    private int numQuestao = 0;
    public bool isPaused = true;
    public GameObject conversas_alan;

    private GameObject alternativa1;
    private GameObject alternativa2;
    private GameObject questao;

    public GameObject cenaRespiracaoOfegante;
    public GameObject cenaCoracaoBatendo;
    public GameObject cenaMaosSoando;
    public GameObject cenaNegacao;
    public GameObject cenaFinal;



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

        atualizaAlternativa(numQuestao);
        atualizaQuestao(numQuestao);

        corretas.Add(0, 1);/*questao 1*//*ok*/
        corretas.Add(1, 2);/*questao 2*//*ok*/
        corretas.Add(2, 5);/*questao 3*//*ok*/
        corretas.Add(3, 6);/*questao 4*//*ok*/
        corretas.Add(4, 8);/*questao 5*//*ok*/
        corretas.Add(5, 11);/*questao 6*//*ok*/
        corretas.Add(6, 13);/*questao 7*//*ok*/
        corretas.Add(7, 15);/*questao 8*//*ok*/
        corretas.Add(8, 16);/*questao 9*//*ok*/
        corretas.Add(9, 18);/*questao 10*//*ok*/


    }

    // Update is called once per frame
    void Update()
    {
        if (!isPaused && numQuestao < 10)
        {
            alternativa1.transform.Translate(Vector3.down * velocidade * Time.deltaTime);
            alternativa2.transform.Translate(Vector3.down * velocidade * Time.deltaTime);

            if (verificaQueda(alternativa1.transform.position.y) && numQuestao < 10)
            {
                jogadorErrou.Value = true;
                conversas_alan.SetActive(true);

                cenaRespiracaoOfegante.SetActive(false);
                cenaMaosSoando.SetActive(false);
                cenaNegacao.SetActive(false);
                cenaFinal.SetActive(false);
                cenaCoracaoBatendo.SetActive(true);

                cenaCoracaoBatendo.GetComponent<TimelineController>().StartTimeline();

                PauseGame();


                atualizaAlternativa(numQuestao);
                atualizaQuestao(numQuestao);
            }
        }

        

    }

    void cenas()
    {
        if (numQuestao == 3 && jogadorErrou.Value == false)
        {
            conversas_alan.SetActive(true);
            cenaCoracaoBatendo.SetActive(false);
            cenaMaosSoando.SetActive(false);
            cenaNegacao.SetActive(false);
            cenaFinal.SetActive(false);
            cenaRespiracaoOfegante.SetActive(true);

            cenaRespiracaoOfegante.GetComponent<TimelineController>().StartTimeline();


            PauseGame();

        }

        if (numQuestao == 5 && jogadorErrou.Value == false)
        {
            conversas_alan.SetActive(true);
            cenaCoracaoBatendo.SetActive(false);
            cenaRespiracaoOfegante.SetActive(false);
            cenaNegacao.SetActive(false);
            cenaFinal.SetActive(false);
            cenaMaosSoando.SetActive(true);

            cenaMaosSoando.GetComponent<TimelineController>().StartTimeline();

            PauseGame();

        }

        if (numQuestao == 7 && jogadorErrou.Value == false)
        {
            conversas_alan.SetActive(true);
            cenaCoracaoBatendo.SetActive(false);
            cenaRespiracaoOfegante.SetActive(false);
            cenaMaosSoando.SetActive(false);
            cenaFinal.SetActive(false);
            cenaNegacao.SetActive(true);

            cenaNegacao.GetComponent<TimelineController>().StartTimeline();

            PauseGame();

        }

        if (numQuestao == 10 && jogadorErrou.Value == false)
        {
            conversas_alan.SetActive(true);
            cenaCoracaoBatendo.SetActive(false);
            cenaRespiracaoOfegante.SetActive(false);
            cenaMaosSoando.SetActive(false);
            cenaNegacao.SetActive(false);
            cenaFinal.SetActive(true);         

            cenaFinal.GetComponent<TimelineController>().StartTimeline();

            PauseGame();
        }
    }

    public void atualiza(BoolVariable errou)
    {
        if (errou.Value == false) {
            ProximaQuestao();
        }
    }

    public void ProximaQuestao()
    {
        numQuestao++;
        if (numQuestao < 10)
        {
            atualizaAlternativa(numQuestao);
            atualizaQuestao(numQuestao);
        }

    }

    private bool validaResposta(int numAlternativa)
    {
        if (corretas[numQuestao] == numAlternativa)
        {
            //Debug.Log("questão correta = " + corretas[numQuestao] + " alternativa selecionada: " + numAlternativa);
            //Debug.Log("resposta correta!!");
            sfxSound.clip = acerto_sound;
            sfxSound.Play();
            sfxSound.loop = false;
            jogadorErrou.Value = false;
            //Debug.Log("****************************VALIDANDO RESPOSTA*************************");
            atualiza(jogadorErrou);

            cenas();
            
            return true;
        }
        else
        {
            //Debug.Log("questão correta = " + corretas[numQuestao] + " alternativa selecionada: " + numAlternativa);
            //Debug.Log("resposta errada!!");

            sfxSound.clip = erro_sound;
            sfxSound.Play();
            sfxSound.loop = false;

            jogadorErrou.Value = true;

            conversas_alan.SetActive(true);
            cenaRespiracaoOfegante.SetActive(false);
            cenaMaosSoando.SetActive(false);
            cenaNegacao.SetActive(false);
            cenaFinal.SetActive(false);
            cenaCoracaoBatendo.SetActive(true);

            cenaCoracaoBatendo.GetComponent<TimelineController>().StartTimeline();

            atualizaAlternativa(numQuestao);
            atualizaQuestao(numQuestao);

            PauseGame();
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
        if (alternativa1 == null || alternativa2 == null) return;

        alternativa1.transform.Translate(Vector3.down * velocidade * Time.deltaTime);
        alternativa2.transform.Translate(Vector3.down * velocidade * Time.deltaTime); // Continua o jogo com o tempo normal
        isPaused = false;
        jogadorErrou.Value = false;
 
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
