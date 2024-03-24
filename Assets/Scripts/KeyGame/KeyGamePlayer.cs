using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyGamePlayer : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private string playerName;
    
    public RectTransform stamina;
    public GameObject WIN;
    private int score = 0;
    public bool catRunning = false;

    PlayerSwipeController playerSwipeController;
    AudioController audioController;



    private void Start()
    {
        updateScore();
        playerSwipeController = gameObject.GetComponent<PlayerSwipeController>();
        audioController = GameObject.Find("AudioController").GetComponent<AudioController>();
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
        score += 1;
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

    public bool achouChave(string moita)
    {
        if (moita == "moitaComChave")
        {
            score++;
            updateScore();
            audioController.WIN();

            
            WIN.SetActive(true);

            //Debug.Log("-----------------VOCE ACHOU A CHAVE ----------------------");

            return true;
        }
        else
        {
            updateScore();
            return false;
        }
    }



}
