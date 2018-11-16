using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    [SerializeField]
    private Text scoreText;

    private int scoreValue = 100;

    private void Update()
    {
        scoreText.text = "Money: " + scoreValue.ToString();
    }

    public int GetScore()
    {
        return scoreValue;
    }

    public void AddScore(int amount)
    {
        scoreValue += amount;
    }
}
