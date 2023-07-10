using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciaMoita : MonoBehaviour
{
    //Esse código vai fazer as estátuas de instanciarem sozinhas em tempo de execução
    [SerializeField] private GameObject Moita;
    [SerializeField] private int maxNumber = 5;//Número máximo de estátuas permitidas no campo
    [SerializeField] private float minDistance = 1.0f;//Distância minima entre as estátuas

    [Header("Positions Parameters")]
    [SerializeField] private float minXPos = -18.5f;
    [SerializeField] private float maxXPos = 10.5f;
    [SerializeField] private float minYPos = -8.5f;
    [SerializeField] private float maxYPos = 4.6f;

    private List<Vector2> occupiedPositions;

    private void Start()
    {
        occupiedPositions = new List<Vector2>//posições do mapa já ocupadas por algum objeto
        {
            new Vector2(0f, 0f),
            new Vector2(1f, 1f),
            new Vector2(1f, -1f),
            new Vector2(-1f, -1f),
            new Vector2(-1f, 1f)
        };

        for (int i = 0; i < maxNumber; i++)
        {
            float x, y;
            bool occupied;

            do
            {
                occupied = false;
                x = Random.Range(minXPos, maxXPos);//vamos colocar a estátua em um local aleatório
                y = Random.Range(minYPos, maxYPos);
                Vector2 tryPosition = new Vector2(x, y);

                foreach (Vector2 otherPosition in occupiedPositions)/*Para cada objeto da cena que possui sua posiçaõ em occupied Positions eu vou comparar com a nova que vou 
                                                                    *colocar. Se o novo objeto estiver perto de qualquer uma delas, vou gerar uma nova posição pra ele*/
                {
                    if (Vector2.Distance(tryPosition, otherPosition) < minDistance)
                        occupied = true;
                }

            } while (occupied);

            Vector2 pos = new Vector2(x, y);//posição onde vamos colocar o objeto
            occupiedPositions.Add(pos);
            GameObject obj = Instantiate<GameObject>(Moita, pos, Quaternion.identity, transform);//objeto, posição, orientação dele e objeto pai do objeto que vamos posicionar
                                                                                                     //No caso ele será filho do GameObject CatStatue pois foi neles que colocamos o script CatStatueInstantiate
            obj.name = "Moita" + i;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
