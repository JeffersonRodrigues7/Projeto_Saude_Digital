using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class LightFilterController : MonoBehaviour
{
    [Header("PostProcessProfiles")]
    public PostProcessProfile manha;
    public PostProcessProfile tarde;
    public PostProcessProfile noite;

    private PostProcessVolume postProcessVolume;

    private void Awake()
    {
        postProcessVolume = GetComponent<PostProcessVolume>();
    }

    private void Start()
    {
        SetFilter();
    }

    private void SetFilter()
    {
        string currentMission = GameManager.Instance.currentMission;

        switch (currentMission)
        {
            case "0":
                SetManha();
                break;
            case "1":
                SetTarde();
                break;
            case "2":
                SetTarde();
                break;
            case "2_minigame":
                SetTarde();
                break;
            case "3":
                SetTarde();
                break;
            case "4_1":
                SetTarde();
                break;
            case "4_2":
                SetTarde();
                break;
            case "4_2_5":
                SetTarde();
                break;
            case "4_minigame":
                SetTarde();
                break;
            case "4_3":
                SetNoite();
                break;
            case "4_4":
                SetNoite();
                break;
            case "5":
                SetNoite();
                break;
            case "6":
                SetManha();
                break;
            case "6_minigame":
                SetManha();
                break;
            case "7":
                SetManha();
                break;
            case "8":
                SetTarde();
                break;
            case "9":
                SetTarde();
                break;
            case "10":
                SetManha();
                break;
            case "11":
                SetTarde();
                break;
            case "12":
                SetNoite();
                break;
            case "13":
                SetNoite();
                break;
            case "14":
                SetManha();
                break;
            default:
                SetTarde();
                break;
        }
    }

    public void SetManha() => postProcessVolume.profile = manha;
    public void SetTarde() => postProcessVolume.profile = tarde;
    public void SetNoite() => postProcessVolume.profile = noite;
    public void SetNull() => postProcessVolume.profile = null;

}
