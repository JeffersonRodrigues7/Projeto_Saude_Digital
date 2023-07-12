using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IAFriends : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private string NPCName;
    [SerializeField] private float speed = 3.0f; //velocidade do guerreiro
    [SerializeField] private int qtdNeigh = 3;
    [SerializeField] private float cooldown = 0.25f;

    private Animator animator;
    private Rigidbody2D rigidbody2d;

    private GameObject[] moitas;
    private GameObject moita;

    private int score;
    private Vector2 lookDirection;
    private float cooldownTime;//Quando o raio do player atingir alguém esse cooldown é setado para que a direção do player para de se mover e ele consiga ir diretamente pro moita e acertar

    private bool started;
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        moitas = null;
        moita = null;

        lookDirection = new Vector2(1, 0);
        score = 0;
        cooldownTime = cooldown;

        started = false;
        updateScore();
    }

    void FixedUpdate()
    {
        if (started)
        {

            moitas = GameObject.FindGameObjectsWithTag("Moita");

            buscaPorChave(moitas);
        }
    }

    GameObject GetClosestmoita(GameObject[] moitas, int k)
    {
        GameObject actualmoita;
        GameObject tempmoita;
        List<GameObject> closestmoitas = new List<GameObject>();
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
        }
        int position = Random.Range(0, k);
        return closestmoitas.ToArray()[position];//retorna posição aleatória dentro do vetor 
    }

    private void updateScore()
    {
        scoreText.text = NPCName + ": " + score;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Moita")
        {
            Destroy(collision.gameObject);
            score++;
            updateScore();
        } else //atualiza a moita que esta procurando, caso bata em objetos no cenário
        {
            moitas = GameObject.FindGameObjectsWithTag("Moita");
            buscaPorChave(moitas);

        } 
        
        if (collision.gameObject.name == "moitaComChave")
        {
            score++;
            updateScore();
            Debug.Log("-----------------SEUS AMIGOS ACHARAM A CHAVE ----------------------");
        }
    }

    public void buscaPorChave (GameObject[] moitas)
    {
        if (moitas.Length == 0)
        {
            moita = null;
            rigidbody2d.velocity = new Vector2(0, 0);
            animator.SetFloat("xDirection", lookDirection.x);
            animator.SetFloat("yDirection", lookDirection.y);
            animator.SetBool("isWalking", false);

        }

        else if (cooldownTime == 0 && moitas.Length < qtdNeigh)
            moita = GetClosestmoita(moitas, moitas.Length);
        else if (cooldownTime == 0)
            moita = GetClosestmoita(moitas, qtdNeigh);

        if (moita != null)
        {
            lookDirection = (moita.transform.position - transform.position).normalized;

            animator.SetFloat("xDirection", lookDirection.x);
            animator.SetFloat("yDirection", lookDirection.y);
            animator.SetBool("isWalking", true);

            rigidbody2d.velocity = new Vector2(lookDirection.x * speed,
                lookDirection.y * speed);
            cooldownTime = cooldown;
        }

        cooldownTime = Mathf.Clamp(cooldownTime - Time.fixedDeltaTime, 0, Mathf.Infinity);

    }


    public int getScore() { return score; }

    public void startGame() { started = true; }
}
