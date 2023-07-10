using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SorteiaMoita : MonoBehaviour
{

    GameObject[] moitas;
    GameObject moitaComChave;

    // Start is called before the first frame update
    void Start()
    {
        moitas = GameObject.FindGameObjectsWithTag("Moita");

        moitaComChave = moitas[Random.Range(0, moitas.Length)];
        Debug.Log("a moita com a chave é: " + moitaComChave.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == moitaComChave.name)
        {
            Debug.Log("-----------------VOCE ACHOU A CHAVE--------------------");
        }
    }
}
