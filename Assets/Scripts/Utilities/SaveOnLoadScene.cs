using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveOnLoadScene : MonoBehaviour
{
    void Start()
    {
        GameManager.Instance.SaveGame();
    }
}
