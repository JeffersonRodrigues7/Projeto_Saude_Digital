using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IACatStatueGame : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private string NPCName;
    [SerializeField] private float speed = 3.0f;//velocidade do guerreiro
    [SerializeField] private int qtdNeigh = 3;
    [SerializeField] private float cooldown = 0.25f;

    private Animator animator;
    private Rigidbody2D rigidbody2d;

    private GameObject[] CatStatues;
    private GameObject catStatue;

    private int score;
    private Vector2 lookDirection;
    private float cooldownTime;//Quando o raio do player atingir alguém esse cooldown é setado para que a direção do player para de se mover e ele consiga ir diretamente pro CatStatue e acertar

    private bool started;
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        CatStatues = null;
        catStatue = null;

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
            CatStatues = GameObject.FindGameObjectsWithTag("CatStatue");

            if (CatStatues.Length == 0)
            {
                catStatue = null;
                rigidbody2d.velocity = new Vector2(0, 0);
                animator.SetFloat("xDirection", lookDirection.x);
                animator.SetFloat("yDirection", lookDirection.y);

            }

            else if (cooldownTime == 0 && CatStatues.Length < qtdNeigh)
                catStatue = GetClosestCatStatue(CatStatues, CatStatues.Length);
            else if (cooldownTime == 0)
                catStatue = GetClosestCatStatue(CatStatues, qtdNeigh);

            if (catStatue != null)
            {
                lookDirection = (catStatue.transform.position - transform.position).normalized;

                animator.SetFloat("xDirection", lookDirection.x);
                animator.SetFloat("yDirection", lookDirection.y);
                animator.SetBool("isWalking", true);

                rigidbody2d.velocity = new Vector2(lookDirection.x * speed,
                    lookDirection.y * speed);
                cooldownTime = cooldown;
            }

            cooldownTime = Mathf.Clamp(cooldownTime - Time.fixedDeltaTime, 0, Mathf.Infinity);
        }
    }

    GameObject GetClosestCatStatue(GameObject[] CatStatues, int k)
    {
        GameObject actualCatStatue;
        GameObject tempCatStatue;
        List<GameObject> closestCatStatues = new List<GameObject>();
        Vector3 currentPosition = transform.position;//Posição atual do player

        for (int i = 0; i < CatStatues.Length; i++)
        {
            actualCatStatue = CatStatues[i];
            Vector3 directionToCatStatue = actualCatStatue.transform.position - currentPosition;
            float distanceToCatStatue = directionToCatStatue.sqrMagnitude;//Distãncia do CatStatue atual para o player

            if (closestCatStatues == null || closestCatStatues.Count < k)
                closestCatStatues.Add(actualCatStatue);
            else
            {
                for (int j = 0; j < k; j++)
                {
                    Vector3 directionToClosestCatStatue = closestCatStatues[j].transform.position - currentPosition;
                    float distanceToClosestCatStatue = directionToClosestCatStatue.sqrMagnitude;//Distancia do CatStatue
                                                                                        //mais proximo para
                                                                                        //o player
                    if (distanceToCatStatue < distanceToClosestCatStatue)//verifica se o catStatue atual está mais
                                                                 //próximo que o catStatue que já estava no vetor
                    {
                        tempCatStatue = closestCatStatues[j];
                        closestCatStatues[j] = actualCatStatue;

                        //Abaixo faço a troca e verifico se o catStatue que perdeu seu lugar está mais próximo
                        //do player do que os outros que tbm estavam no vetor
                        actualCatStatue = tempCatStatue;
                        directionToCatStatue = actualCatStatue.transform.position - currentPosition;
                        distanceToCatStatue = directionToCatStatue.sqrMagnitude;
                    }
                }
            }
        }
        int position = Random.Range(0, k);
        return closestCatStatues.ToArray()[position];//retorna posição aleatória dentro do vetor 
    }

    private void updateScore()
    {
        scoreText.text = NPCName + ": " + score;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "CatStatue")
        {
            Destroy(collision.gameObject);
            score++;
            updateScore();
        }
    }

    public int getScore() { return score; }

    public void startGame() { started = true; }
}
