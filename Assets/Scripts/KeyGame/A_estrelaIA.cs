using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class A_estrelaIA : MonoBehaviour
{
    // Start is called before the first frame update

    private NavMeshAgent friend;
    private GameObject[] moitas;

    public GameObject player;

    void Start()
    {
        friend = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        moitas = GameObject.FindGameObjectsWithTag("Moita");

        if(moitas.Length != 0)
        {
           
            friend.SetDestination(player.transform.position);
            Debug.Log("entrei estou procurando" + player.name);

        }

    }

    GameObject GetClosestmoita(GameObject[] moitas, int k)
    {
        GameObject actualmoita;
        GameObject tempmoita;
        List<GameObject> closestmoitas = new List<GameObject>();
        Vector3 currentPosition = transform.position;//Posi��o atual do player

        for (int i = 0; i < moitas.Length; i++)
        {
            actualmoita = moitas[i];
            Vector3 directionTomoita = actualmoita.transform.position - currentPosition;
            float distanceTomoita = directionTomoita.sqrMagnitude;//Dist�ncia do moita atual para o player

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
                    if (distanceTomoita < distanceToClosestmoita)//verifica se o moita atual est� mais
                                                                 //pr�ximo que o moita que j� estava no vetor
                    {
                        tempmoita = closestmoitas[j];
                        closestmoitas[j] = actualmoita;

                        //Abaixo fa�o a troca e verifico se o moita que perdeu seu lugar est� mais pr�ximo
                        //do player do que os outros que tbm estavam no vetor
                        actualmoita = tempmoita;
                        directionTomoita = actualmoita.transform.position - currentPosition;
                        distanceTomoita = directionTomoita.sqrMagnitude;
                    }
                }
            }
        }
        int position = Random.Range(0, k);


        return closestmoitas.ToArray()[position];//retorna posi��o aleat�ria dentro do vetor 
    }
}
