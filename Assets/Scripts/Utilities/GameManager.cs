using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;

    public string lastSceneVisited = "Null";
    public string currentMission = "0";

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
    public bool cena4_4 = false;
    public bool cena5 = false;
    public bool cena6 = false;
    public bool cena6_minigame = false;
    public bool cena7 = false;
    public bool cena8 = false;
    public bool cena9 = false;
    public bool cena10 = false;
    public bool cena11 = false;
    public bool cena12 = false;
    public bool cena13 = false;
    public bool cena14 = false;

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
                currentMission = "1";
                break;
            case "1":
                cena1 = true;
                currentMission = "2";
                break;
            case "2":
                cena2 = true;
                currentMission = "2_minigame";
                break;
            case "2_minigame":
                cena2_minigame = true;
                currentMission = "3";
                break;
            case "3":
                cena3 = true;
                currentMission = "4_1";
                break;
            case "4_1":
                cena4_1 = true;
                currentMission = "4_2";
                break;
            case "4_2":
                cena4_2 = true;
                currentMission = "4_2_5";
                break;
            case "4_2_5":
                cena4_2_5 = true;
                currentMission = "4_minigame";
                break;
            case "4_minigame":
                cena4_minigame = true;
                currentMission = "4_3";
                break;
            case "4_3":
                cena4_3 = true;
                currentMission = "4_4";
                break;            
            case "4_4":
                cena4_4 = true;
                currentMission = "5";
                break;
            case "5":
                cena5 = true;
                currentMission = "6";
                break;
            case "6":
                cena6 = true;
                currentMission = "6_minigame";
                break;
            case "6_minigame":
                cena6_minigame = true;
                currentMission = "7";
                break;
            case "7":
                cena7 = true;
                currentMission = "8";
                break;
            case "8":
                cena8 = true;
                currentMission = "9";
                break;
            case "9":
                cena9 = true;
                currentMission = "10";
                break;
            case "10":
                cena10 = true;
                currentMission = "11";
                break;
            case "11":
                cena11 = true;
                currentMission = "12";
                break;
            case "12":
                cena12 = true;
                currentMission = "13";
                break;
            case "13":
                cena13 = true;
                currentMission = "14";
                break;
            case "14":
                cena14 = true;
                currentMission = "15";
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
            case "4_4":
                return cena4_4;
            case "5":
                return cena5;
            case "6":
                return cena6;
            case "6_minigame":
                return cena6_minigame;
            case "7":
                return cena7;
            case "8":
                return cena8;
            case "9":
                return cena9;
            case "10":
                return cena10;
            case "11":
                return cena11;
            case "12":
                return cena12;
            case "13":
                return cena13;
            case "14":
                return cena14;
            default:
                Debug.Log("Não encontrado cena de valor para Buscar: " + cena);
                return false;
        }
    }
}
