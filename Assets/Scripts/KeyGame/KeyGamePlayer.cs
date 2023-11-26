using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyGamePlayer : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private string playerName;
    public AudioController audioController;
    public AudioClip voceAchouChave;
    public RectTransform stamina;
    public Button buttonRun;
    public Button buttonSearch;
    public GameObject WIN;
    private int score = 0;
    public bool catRunning = false;

    PlayerSwipeController playerSwipeController; 



    private void Start()
    {
        updateScore();
        playerSwipeController = gameObject.GetComponent<PlayerSwipeController>(); 
    }

    public void Update()
    {

        if (catRunning)
        {
            float novaStamina = Mathf.Max(stamina.sizeDelta.x - 0.5f, 0f);    
            stamina.sizeDelta = new Vector2(novaStamina, stamina.sizeDelta.y);
            catRun();
        }
        else
        {
            float novaStamina = Mathf.Min(stamina.sizeDelta.x + 0.2f, 157.0f);
            stamina.sizeDelta = new Vector2(novaStamina, stamina.sizeDelta.y);
            
        }
        
    }

    private void updateScore()
    {
        scoreText.text = playerName + ": " + score;
    }

    public void catRun()
    {
        if (stamina.sizeDelta.x > 0.1f)
        {
            playerSwipeController.moveSpeed = 10.0f;
            catRunning = true;
        }
        else
        {
            catWalk();
        }
    }

    public void catWalk()
    {
        playerSwipeController.moveSpeed = 3.0f;
        catRunning = false;
    }



}
