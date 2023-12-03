using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;
using UnityEngine.UI;

public class A_estrelaIA : MonoBehaviour
{
    // Start is called before the first frame update

    private NavMeshAgent agent;
    private GameObject[] moitas;
    private float cooldown = 3f;
    private float cooldownTime;
    private GameObject moitaTarget;
    public GameObject WIN;
    AudioController audioController;

    [SerializeField] private Text scoreText;
    public string NPCName;
    private int score;
 

    private bool started;

    private Animator animator;
    private Vector2 lookDirection; 


    void Start()
    {
        animator = GetComponent<Animator>();
        score = 0;

        lookDirection = new Vector2(1, 0);
        started = false;

        audioController = GameObject.Find("AudioController").GetComponent<AudioController>();


        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        updateScore();

        cooldownTime = cooldown;
    }

    public void startGame() { started = true; }

    private void updateScore()
    {
        scoreText.text = NPCName + ": " + score;
    }

    // Update is called once per frame
    void Update()
    {
        if (started == true)
        {
            

            moitas = GameObject.FindGameObjectsWithTag("Moita");

            if (moitaTarget != null && cooldownTime == 0)
            {

                //Debug.Log("estou procurando" + moitaTarget.name);
                agent.SetDestination(moitaTarget.transform.position);

                lookDirection = (moitaTarget.transform.position - transform.position).normalized;

                animator.SetFloat("xDirection", lookDirection.x);
                animator.SetFloat("yDirection", lookDirection.y);
                animator.SetBool("isWalking", true);

                cooldownTime = cooldown;
            }
            else if (moitaTarget == null)
            {
                moitaTarget = GetClosestmoita(moitas, moitas.Length);
            }

            cooldownTime = Mathf.Clamp(cooldownTime - Time.fixedDeltaTime, 0, Mathf.Infinity);
            //Debug.Log(cooldownTime);

        }



    }

    GameObject GetClosestmoita(GameObject[] moitas, int k)
    {
        GameObject actualmoita;
        GameObject tempmoita;
        List<GameObject> closestmoitas = new List<GameObject>();
        List<float> distanciasMoitas = new List<float>();
        Vector3 currentPosition = transform.position;//Posição atual do player

        for (int i = 0; i < moitas.Length; i++)
        {
            actualmoita = moitas[i];
            Vector3 directionTomoita = actualmoita.transform.position - currentPosition;
            float distanceTomoita = directionTomoita.sqrMagnitude;//Distãncia do moita atual para o player

            if (closestmoitas == null || closestmoitas.Count < k)
                closestmoitas.Add(actualmoita);
            else
            {
                for (int j = 0; j < k; j++)
                {
                    Vector3 directionToClosestmoita = closestmoitas[j].transform.position - currentPosition;
                    float distanceToClosestmoita = directionToClosestmoita.sqrMagnitude;//Distancia do moita
                                                                                        //mais proximo para
                                                                                        //o player
                    if (distanceTomoita < distanceToClosestmoita)//verifica se o moita atual está mais
                                                                 //próximo que o moita que já estava no vetor
                    {
                        tempmoita = closestmoitas[j];
                        closestmoitas[j] = actualmoita;

                        //Abaixo faço a troca e verifico se o moita que perdeu seu lugar está mais próximo
                        //do player do que os outros que tbm estavam no vetor
                        actualmoita = tempmoita;
                        directionTomoita = actualmoita.transform.position - currentPosition;
                        distanceTomoita = directionTomoita.sqrMagnitude;
                    }
                }
            }

            distanciasMoitas.Add(distanceTomoita);

        }
        int position = Random.Range(0, k);


        return closestmoitas.ToArray()[distanciasMoitas.IndexOf(Mathf.Min(distanciasMoitas.ToArray()))];//retorna posição aleatória dentro do vetor 
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Moita")
        {
            score++;
            updateScore();
            SearchingKey();
            Destroy(collision.gameObject);
 
        }
        else //atualiza a moita que esta procurando, caso bata em objetos no cenário
        {
            moitas = GameObject.FindGameObjectsWithTag("Moita");
 

        }

        if (collision.gameObject.name == "moitaComChave")
        {
            score++;
            updateScore();
            audioController.WIN();
            
            WIN.SetActive(true);

            GameObject player = GameObject.FindGameObjectsWithTag("Player")[0];

            Vector3 posicaoPlayer = new Vector3(player.transform.position.x, player.transform.position.y);
            agent.SetDestination(posicaoPlayer);

            started = false;

            Debug.Log("-----------------SEUS AMIGOS ACHARAM A CHAVE ----------------------");
        }
    }

    IEnumerator SearchingKey()
    {
        yield return new WaitForSeconds(2);
    }

    

    }
