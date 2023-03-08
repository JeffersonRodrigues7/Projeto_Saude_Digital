using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatStatueInstantiate : MonoBehaviour
{
    //Esse c�digo vai fazer as est�tuas de instanciarem sozinhas em tempo de execu��o
    [SerializeField] private GameObject catStatue;
    [SerializeField] private int maxNumber = 5;//N�mero m�ximo de est�tuas permitidas no campo
    private List<Vector2> occupiedPositions;

    private void Start()
    {
        occupiedPositions = new List<Vector2>//posi��es do mapa j� ocupadas por algum objeto
        {
            new Vector2(0f, 0f)
        };

        for (int i = 0; i < maxNumber; i++)
        {
            float x, y;
            bool occupied;

            do
            {
                occupied = false;
                x = Random.Range(-10f, 10f);//vamos colocar a est�tua em um local aleat�rio
                y = Random.Range(-10f, 10f);
                Vector2 tryPosition = new Vector2(x, y);

                foreach (Vector2 otherPosition in occupiedPositions)/*Para cada objeto da cena que possui sua posi�a� em occupied Positions eu vou comparar com a nova que vou 
                                                                    *colocar. Se o novo objeto estiver perto de qualquer uma delas, vou gerar uma nova posi��o pra ele*/
                {
                    if (Vector2.Distance(tryPosition, otherPosition) < 1f)
                        occupied = true;
                }

            } while (occupied);

            Vector2 pos = new Vector2(x, y);//posi��o onde vamos colocar o objeto
            occupiedPositions.Add(pos);
            GameObject obj = Instantiate<GameObject>(catStatue, pos, Quaternion.identity, transform);//objeto, posi��o, orienta��o dele e objeto pai do objeto que vamos posicionar
                                                                                                     //No caso ele ser� filho do GameObject CatStatue pois foi neles que colocamos o script CatStatueInstantiate
            obj.name = "CatStatue" + i;
        }
    }
}
