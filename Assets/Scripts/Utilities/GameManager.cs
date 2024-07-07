using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;

    public string currentScene = "";
    public bool isNewDay = false;
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
    public bool cena12_minigame = false;
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

        SetInitialValues();
        LoadGame();
    }

    private void SetInitialValues()
    {
        currentScene = "";
        isNewDay = false;
        lastSceneVisited = "Null";
        currentMission = "0";

        cena0 = false;
        cena1 = false;
        cena2 = false;
        cena2_minigame = false;
        cena3 = false;
        cena4_1 = false;
        cena4_2 = false;
        cena4_2_5 = false;
        cena4_minigame = false;
        cena4_3 = false;
        cena4_4 = false;
        cena5 = false;
        cena6 = false;
        cena6_minigame = false;
        cena7 = false;
        cena8 = false;
        cena9 = false;
        cena10 = false;
        cena11 = false;
        cena12 = false;
        cena12_minigame = false;
        cena13 = false;
        cena14 = false;
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
                currentMission = "12_minigame";
                break;
            case "12_minigame":
                cena12_minigame = true;
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

        SaveGame();
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
            case "12_minigame":
                return cena12_minigame;
            case "13":
                return cena13;
            case "14":
                return cena14;
            case "99": //Para a cena 0 executar
                return true;
            default:
                Debug.Log("Não encontrado cena de valor para Buscar: " + cena);
                return false;
        }
    }

    //Chamado ao entrar em uma nova scene ou ao iniciar uma nova cinematica
    public void SaveGame()
    {
        // Salva o nome da cena atual
        currentScene = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("SavedScene", currentScene);

        PlayerPrefs.SetInt("cena0", cena0 ? 1 : 0);
        PlayerPrefs.SetInt("cena1", cena1 ? 1 : 0);
        PlayerPrefs.SetInt("cena2", cena2 ? 1 : 0);
        PlayerPrefs.SetInt("cena2_minigame", cena2_minigame ? 1 : 0);
        PlayerPrefs.SetInt("cena3", cena3 ? 1 : 0);
        PlayerPrefs.SetInt("cena4_1", cena4_1 ? 1 : 0);
        PlayerPrefs.SetInt("cena4_2", cena4_2 ? 1 : 0);
        PlayerPrefs.SetInt("cena4_2_5", cena4_2_5 ? 1 : 0);
        PlayerPrefs.SetInt("cena4_minigame", cena4_minigame ? 1 : 0);
        PlayerPrefs.SetInt("cena4_3", cena4_3 ? 1 : 0);
        PlayerPrefs.SetInt("cena4_4", cena4_4 ? 1 : 0);
        PlayerPrefs.SetInt("cena5", cena5 ? 1 : 0);
        PlayerPrefs.SetInt("cena6", cena6 ? 1 : 0);
        PlayerPrefs.SetInt("cena6_minigame", cena6_minigame ? 1 : 0);
        PlayerPrefs.SetInt("cena7", cena7 ? 1 : 0);
        PlayerPrefs.SetInt("cena8", cena8 ? 1 : 0);
        PlayerPrefs.SetInt("cena9", cena9 ? 1 : 0);
        PlayerPrefs.SetInt("cena10", cena10 ? 1 : 0);
        PlayerPrefs.SetInt("cena11", cena11 ? 1 : 0);
        PlayerPrefs.SetInt("cena12", cena12 ? 1 : 0);
        PlayerPrefs.SetInt("cena12_minigame", cena12_minigame ? 1 : 0);
        PlayerPrefs.SetInt("cena13", cena13 ? 1 : 0);
        PlayerPrefs.SetInt("cena14", cena14 ? 1 : 0);

        PlayerPrefs.SetInt("isNewDay", isNewDay ? 1 : 0);
        PlayerPrefs.SetString("lastSceneVisited", lastSceneVisited);
        PlayerPrefs.SetString("currentMission", currentMission);

        PlayerPrefs.Save();

        Debug.Log("Jogo Salvo!");
    }

    public void LoadGame()
    {
        currentScene = PlayerPrefs.GetString("SavedScene");

        cena0 = PlayerPrefs.GetInt("cena0", 0) == 1;
        cena1 = PlayerPrefs.GetInt("cena1", 0) == 1;
        cena2 = PlayerPrefs.GetInt("cena2", 0) == 1;
        cena2_minigame = PlayerPrefs.GetInt("cena2_minigame", 0) == 1;
        cena3 = PlayerPrefs.GetInt("cena3", 0) == 1;
        cena4_1 = PlayerPrefs.GetInt("cena4_1", 0) == 1;
        cena4_2 = PlayerPrefs.GetInt("cena4_2", 0) == 1;
        cena4_2_5 = PlayerPrefs.GetInt("cena4_2_5", 0) == 1;
        cena4_minigame = PlayerPrefs.GetInt("cena4_minigame", 0) == 1;
        cena4_3 = PlayerPrefs.GetInt("cena4_3", 0) == 1;
        cena4_4 = PlayerPrefs.GetInt("cena4_4", 0) == 1;
        cena5 = PlayerPrefs.GetInt("cena5", 0) == 1;
        cena6 = PlayerPrefs.GetInt("cena6", 0) == 1;
        cena6_minigame = PlayerPrefs.GetInt("cena6_minigame", 0) == 1;
        cena7 = PlayerPrefs.GetInt("cena7", 0) == 1;
        cena8 = PlayerPrefs.GetInt("cena8", 0) == 1;
        cena9 = PlayerPrefs.GetInt("cena9", 0) == 1;
        cena10 = PlayerPrefs.GetInt("cena10", 0) == 1;
        cena11 = PlayerPrefs.GetInt("cena11", 0) == 1;
        cena12 = PlayerPrefs.GetInt("cena12", 0) == 1;
        cena12_minigame = PlayerPrefs.GetInt("cena12_minigame", 0) == 1;
        cena13 = PlayerPrefs.GetInt("cena13", 0) == 1;
        cena14 = PlayerPrefs.GetInt("cena14", 0) == 1;

        isNewDay = PlayerPrefs.GetInt("isNewDay", 0) == 1;
        lastSceneVisited = PlayerPrefs.GetString("lastSceneVisited");
        currentMission = PlayerPrefs.GetString("currentMission");
    }

    //chamado via botão de continuar
    public void LoadScene()
    {
        if (!string.IsNullOrEmpty(currentScene))
        {
            SceneManager.LoadScene(currentScene);
        }
    }

    //chamado via botão de new game
    public void ResetGame()
    {
        //PlayerPrefs.Save();
        SetInitialValues();

        Debug.Log("Jogo Resetado!");
    }
}
