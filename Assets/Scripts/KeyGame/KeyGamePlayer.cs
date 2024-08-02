using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class KeyGamePlayer : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private string playerName;

    public RectTransform stamina;
    public GameObject WIN;
    private int score;
    public bool catRunning;

    PlayerSwipeController playerSwipeController;
    AudioController audioController;

    private void Start()
    {
        updateScore();
        playerSwipeController = gameObject.GetComponent<PlayerSwipeController>();
        audioController = GameObject.Find("AudioController").GetComponent<AudioController>();
        catRunning = false;
        score = 0;
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

    public void callVillage()
    {

        GameManager.Instance.SetCenaTrue("4_minigame");

        FindObjectOfType<PlayerStartPositionSetter>().newPositionData.setPos = true;
        FindObjectOfType<PlayerStartPositionSetter>().newPositionData.vector3Position = new Vector3(-3f, 16.5f, 0);

        GameManager.Instance.lastSceneVisited = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("Village");
    }



}
