using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class InstanciaMoita : MonoBehaviour
{
    //Esse código vai fazer as moitas de instanciarem sozinhas em tempo de execução
    [SerializeField] private GameObject Moita;
    private List<GameObject> moitasCriadas = new List<GameObject>();
    [SerializeField] private int maxNumber = 50;//Número máximo de moitas permitidas no campo
    [SerializeField] private float minDistance = 3.5f;//Distância minima entre as moitas

    [Header("Positions Parameters")]
    [SerializeField] private float minXPos;
    [SerializeField] private float maxXPos;
    [SerializeField] private float minYPos;
    [SerializeField] private float maxYPos;

    public TilemapCollider2D tilemapCollider; 

    public Transform player;
    private GameObject moitaComChave;
 

    private void Start()
    {
       

        for (int i = 0; i < maxNumber; i++)
        {
            float x, y;

            x = Random.Range(minXPos, maxXPos);
            y = Random.Range(minYPos, maxYPos);
            Vector2 pos = new Vector2(x, y);//posição onde vamos colocar o objeto
            
            GameObject obj = Instantiate<GameObject>(Moita, pos, Quaternion.identity, transform);//objeto, posição, orientação dele e objeto pai do objeto que vamos posicionar
                                                                                                     //No caso ele será filho do GameObject CatStatue pois foi neles que colocamos o script CatStatueInstantiate
            obj.name = "Moita" + i;
            moitasCriadas.Add(obj);

        }


        moitaComChave = sorteiaMoita();
        moitaComChave.name = "moitaComChave";

    }

    private GameObject sorteiaMoita()
    {
        GameObject moitaComChave = null;

        while(moitaComChave == null)
        {
            GameObject moitaSorteada = moitasCriadas[Random.Range(0, maxNumber - 1)];

            float distancia_x = moitaSorteada.transform.position.x - player.position.x;
            float distancia_y = moitaSorteada.transform.position.y - player.position.y;

            ////Debug.Log("distancia_x= " + distancia_x + " | distancia_y= " +distancia_y );


            if (distancia_x < -30 || distancia_y < -20)
            {
                moitaComChave = moitaSorteada;
            }
        }
         

        return moitaComChave;
    }

    // Update is called once per frame
    void Update()
    {
               
    }




}
