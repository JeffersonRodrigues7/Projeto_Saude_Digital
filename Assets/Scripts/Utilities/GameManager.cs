using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;

    public bool cena0 = false;
    public bool cena1 = false;
    public bool cena2 = false;
    public bool cena3 = false;
    public bool cena4_1 = false;
    public bool cena4_2 = false;
    public bool cena4_2_5 = false;
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
            default:  
                break;
        }
    }

    public bool GetCenaValue(string cena)
    {
        switch (cena)
        {
            case "0":
                return cena0;
            default:
                return false;
        }
    }
}
