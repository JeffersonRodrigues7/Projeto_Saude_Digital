using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyGamePlayer : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private string playerName;
    private int score = 0;

    private void Start()
    {
        updateScore();
    }

    private void updateScore()
    {
        scoreText.text = playerName + ": " + score;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Moita")
        {
            Destroy(collision.gameObject);
            score++;
            updateScore();
        }else
        {
            Debug.Log(collision.gameObject.name);
        }

        if (collision.gameObject.name == "moitaComChave")
        {
            score++;
            updateScore();
            Debug.Log("-----------------VOCE ACHOU A CHAVE ----------------------");
        }
    }
}
