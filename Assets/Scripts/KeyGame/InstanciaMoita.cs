using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciaMoita : MonoBehaviour
{
    //Esse c�digo vai fazer as moitas de instanciarem sozinhas em tempo de execu��o
    [SerializeField] private GameObject Moita;
    [SerializeField] private int maxNumber = 50;//N�mero m�ximo de moitas permitidas no campo
    [SerializeField] private float minDistance = 1.0f;//Dist�ncia minima entre as moitas

    [Header("Positions Parameters")]
    [SerializeField] private float minXPos = -15.5f;
    [SerializeField] private float maxXPos = 11.5f;
    [SerializeField] private float minYPos = -6.5f;
    [SerializeField] private float maxYPos = 6.7f;



    private List<Vector2> occupiedPositions;

    private void Start()
    {
        occupiedPositions = new List<Vector2>//posi��es do mapa j� ocupadas por algum objeto
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
                x = Random.Range(minXPos, maxXPos);//vamos colocar a est�tua em um local aleat�rio
                y = Random.Range(minYPos, maxYPos);
                Vector2 tryPosition = new Vector2(x, y);

                foreach (Vector2 otherPosition in occupiedPositions)/*Para cada objeto da cena que possui sua posi�a� em occupied Positions eu vou comparar com a nova que vou 
                                                                    *colocar. Se o novo objeto estiver perto de qualquer uma delas, vou gerar uma nova posi��o pra ele*/
                {
                    if (Vector2.Distance(tryPosition, otherPosition) < minDistance)
                        occupied = true;
                }

            } while (occupied);

            Vector2 pos = new Vector2(x, y);//posi��o onde vamos colocar o objeto
            occupiedPositions.Add(pos);
            GameObject obj = Instantiate<GameObject>(Moita, pos, Quaternion.identity, transform);//objeto, posi��o, orienta��o dele e objeto pai do objeto que vamos posicionar
                                                                                                     //No caso ele ser� filho do GameObject CatStatue pois foi neles que colocamos o script CatStatueInstantiate
            obj.name = "Moita" + i;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
