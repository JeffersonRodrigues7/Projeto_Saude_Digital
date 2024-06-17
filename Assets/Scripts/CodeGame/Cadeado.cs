using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Cadeado : MonoBehaviour
{
    public TextMeshProUGUI digito1;
    public TextMeshProUGUI digito2;
    public TextMeshProUGUI digito3;

    public AudioSource soundFX;
    public AudioClip cadeadoDesbloqueado;
    public AudioClip cadeadoTentativa;
    public AudioClip cadeadoMovimentacao;

    public GameObject arcoCadeado;

    public int index1;
    public int index2;
    public int index3;

    List<char> lista_letras = new List<char>();

    public float shakeDuration = 0.5f;
    public float shakeMagnitude = 0.1f;
    private Vector3 originalPosition;

    public GameObject mensagemVitoria;



    // Start is called before the first frame update
    void Start()
    {
        digito1.text = "A";
        digito2.text = "A";
        digito3.text = "A";

        // Salva a posição original do GameObject
        originalPosition = transform.localPosition;



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
        
    }

    public void verificaSenha()
    {
        if (digito1.text == "P" && digito2.text == "A" && digito3.text == "Z")
        {
            soundFX.clip = cadeadoDesbloqueado;
            soundFX.Play();

            Debug.Log("Cadeado aberto!");
            arcoCadeado.transform.localScale = new Vector3(arcoCadeado.transform.localScale.x, 2.0f, arcoCadeado.transform.localScale.z);

            mensagemVitoria.SetActive(true);


        }
        else
        {
            TriggerShake();
            soundFX.clip = cadeadoTentativa;
            soundFX.Play();
            
        }
        
     
    }

    int voltaIndexCadeado(int index)
    {
        if (index > 26)
        {
            return 0;
        }
        else if (index < 0)
        {
            return 26;
        }
        else return index;
    }


    public void atualizaLetraAcima(int digito)
    {
        soundFX.clip = cadeadoMovimentacao;
        soundFX.Play();
        switch (digito)
        {
            case 1:
                index1 += 1;
                index1 = voltaIndexCadeado(index1);
                    digito1.text = lista_letras[index1].ToString();
                
                break;
            case 2:
                index2 += 1;
                index2 = voltaIndexCadeado(index2);
                digito2.text = lista_letras[index2].ToString();
                
                break;
            case 3:
                index3 += 1;
                index3 = voltaIndexCadeado(index3);
                digito3.text = lista_letras[index3].ToString();
                
                break;

        }
        
    }
    public void atualizaLetraAbaixo(int digito)
    {
        soundFX.clip = cadeadoMovimentacao;
        soundFX.Play();
        switch (digito)
        {
            case 1:
                index1 -= 1;
                index1 = voltaIndexCadeado(index1);
                digito1.text = lista_letras[index1].ToString();
                
                break;
            case 2:
                index2 -= 1;
                index2 = voltaIndexCadeado(index2);
                digito2.text = lista_letras[index2].ToString();
                
                break;
            case 3:
                index3 -= 1;
                index3 = voltaIndexCadeado(index3);
                digito3.text = lista_letras[index3].ToString();
                
                break;

        }

    }





    // Método para iniciar o efeito de sacudida
    public void TriggerShake()
    {
        StartCoroutine(Shake());
    }

    // Corrotina que realiza o efeito de sacudida
    IEnumerator Shake()
    {
        float elapsed = 0.0f;

        while (elapsed < shakeDuration)
        {
            Vector3 randomPoint = originalPosition + Random.insideUnitSphere * shakeMagnitude;
            transform.localPosition = randomPoint;
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = originalPosition;
    }


    public void callOldStudent()
    {

        GameManager.Instance.SetCenaTrue("12_minigame");
        GameManager.Instance.lastSceneVisited = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("OldStudentRoom");
    }



}
