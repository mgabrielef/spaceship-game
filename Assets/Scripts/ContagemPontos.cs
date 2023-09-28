using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ContagemPontos : MonoBehaviour
{
    public static int score;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        score = 0;
        UpdateScore();
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "PONTOS: " + score;
    }
}
