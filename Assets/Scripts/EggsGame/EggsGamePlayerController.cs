using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EggsGamePlayerController : MonoBehaviour
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
        if (collision.gameObject.tag == "CatStatue")
        {
            Destroy(collision.gameObject);
            score++;
            updateScore();
        }
    }
}
