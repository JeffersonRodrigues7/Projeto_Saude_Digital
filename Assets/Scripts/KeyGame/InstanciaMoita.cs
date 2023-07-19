using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciaMoita : MonoBehaviour
{
    //Esse c�digo vai fazer as moitas de instanciarem sozinhas em tempo de execu��o
    [SerializeField] private GameObject Moita;
    private List<GameObject> moitasCriadas = new List<GameObject>();
    [SerializeField] private int maxNumber = 50;//N�mero m�ximo de moitas permitidas no campo
    [SerializeField] private float minDistance = 1.0f;//Dist�ncia minima entre as moitas

    [Header("Positions Parameters")]
    [SerializeField] private float minXPos;
    [SerializeField] private float maxXPos;
    [SerializeField] private float minYPos;
    [SerializeField] private float maxYPos;

    public Transform player;
    private GameObject moitaComChave;





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
            moitasCriadas.Add(obj);

        }


        moitaComChave = sorteiaMoita();
        Debug.Log("a moita com a chave �: " + moitaComChave.name);

        moitaComChave.name = "moitaComChave";

    }

    private GameObject sorteiaMoita()
    {
        GameObject moitaComChave = null;
        GameObject moitaSorteada = moitasCriadas[Random.Range(0, maxNumber - 1)];

        float distancia_x = moitaSorteada.transform.position.x - player.position.x;
        float distancia_y = moitaSorteada.transform.position.y - player.position.y;

        Debug.Log("distancia_x= " + distancia_x + " | distancia_y= " +distancia_y );
        

        if (distancia_x < -30 || distancia_y < -20)
        {
            moitaComChave = moitaSorteada;

        } else sorteiaMoita();

        return moitaComChave;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
