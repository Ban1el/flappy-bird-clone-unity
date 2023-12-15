using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scorer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    private int score = 0;

    private void OnEnable()
    {
        Actions.OnEnterObstacle += AddScore;
    }

    private void OnDisable()
    {
        Actions.OnEnterObstacle -= AddScore;
    }

    private void AddScore()
    {
        score++;
        scoreText.SetText(score.ToString());
    }
}
