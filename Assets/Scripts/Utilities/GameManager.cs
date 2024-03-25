using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;

    public bool cena0 = false;
    public bool cena1 = false;
    public bool cena2 = false;
    public bool cena2_minigame = false;
    public bool cena3 = false;
    public bool cena4_1 = false;
    public bool cena4_2 = false;
    public bool cena4_2_5 = false;
    public bool cena4_minigame = false;
    public bool cena4_3 = false;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("GM").AddComponent<GameManager>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null)
        {
            DestroyImmediate(this);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this);
    }

    public void SetCenaTrue(string cena)
    {
        switch(cena)
        {
            case "0":
                cena0 = true; 
                break;
            case "1":
                cena1 = true;
                break;
            case "2":
                cena2 = true;
                break;
            case "2_minigame":
                cena2_minigame = true;
                break;
            case "3":
                cena3 = true;
                break;
            case "4_1":
                cena4_1 = true;
                break;
            case "4_2":
                cena4_2 = true;
                break;
            case "4_2_5":
                cena4_2_5 = true;
                break;
            case "4_minigame":
                cena4_minigame = true;
                break;
            case "4_3":
                cena4_3 = true;
                break;
            default:
                Debug.Log("Não encontrado cena de valor para Setar: " + cena);
                break;
        }
    }

    public bool GetCenaValue(string cena)
    {
        switch (cena)
        {
            case "0":
                return cena0;
            case "1":
                return cena1;
            case "2":
                return cena2;
            case "2_minigame":
                return cena2_minigame;
            case "3":
                return cena3;
            case "4_1":
                return cena4_1;
            case "4_2":
                return cena4_2;
            case "4_2_5":
                return cena4_2_5;
            case "4_minigame":
                return cena4_minigame;
            case "4_3":
                return cena4_3;
            default:
                Debug.Log("Não encontrado cena de valor para Buscar: " + cena);
                return false;
        }
    }
}
