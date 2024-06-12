using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cadeado : MonoBehaviour
{
    public TextMeshProUGUI digito1;
    public TextMeshProUGUI digito2;
    public TextMeshProUGUI digito3;

    public GameObject arcoCadeado;

    public int index1;
    public int index2;
    public int index3;

    List<char> lista_letras = new List<char>();



    // Start is called before the first frame update
    void Start()
    {
        digito1.text = "A";
        digito2.text = "A";
        digito3.text = "A";



        int i = 0;
        for (char letra = 'A'; letra <= 'Z'; letra++)
        {
            lista_letras.Add(letra);
            Debug.Log(lista_letras[i]);
            i += 1;
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        if (verificaSenha())
        {
            Debug.Log("Cadeado aberto!");
            arcoCadeado.transform.localScale = new Vector3(arcoCadeado.transform.localScale.x, 2.0f, arcoCadeado.transform.localScale.z);

        }
    }

    bool verificaSenha()
    {
        return digito1.text == "P" && digito2.text == "A" && digito3.text == "Z";
    }

    bool verificaIndexCadeado(int index)
    {
        if (index > 26 || index < 0)
        {
            return false;
        }else return true;
    }


    public void atualizaLetraAcima(int digito)
    {
        switch (digito)
        {
            case 1:
                index1 += 1;
                if (verificaIndexCadeado(index1))
                {
                    digito1.text = lista_letras[index1].ToString();
                }
                break;
            case 2:
                index2 += 1;
                if (verificaIndexCadeado(index2))
                {
                    digito2.text = lista_letras[index2].ToString();
                }
                break;
            case 3:
                index3 += 1;
                if (verificaIndexCadeado(index3))
                {
                    digito3.text = lista_letras[index3].ToString();
                }
                break;

        }
        
    }
    public void atualizaLetraAbaixo(int digito)
    {
        switch (digito)
        {
            case 1:
                index1 -= 1;
                if (verificaIndexCadeado(index1))
                {
                    digito1.text = lista_letras[index1].ToString();
                }
                break;
            case 2:
                index2 -= 1;
                if (verificaIndexCadeado(index2))
                {
                    digito2.text = lista_letras[index2].ToString();
                }
                break;
            case 3:
                index3 -= 1;
                if (verificaIndexCadeado(index3))
                {
                    digito3.text = lista_letras[index3].ToString();
                }
                break;

        }

    }
}
