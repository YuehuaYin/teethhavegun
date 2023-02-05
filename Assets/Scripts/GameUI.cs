using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public int score;
    public int lives = GameStatistics.maxHealth;
    public Text scoreText;
    public Text livesText;

    public void addScore(int add)
    {
        score += add;
        scoreText.text = score.ToString();
    }

    [ContextMenu("Initial life")]
    public void startLife()
    {
        livesText.text = lives.ToString();
    }

    [ContextMenu("Lose life")]
    public void loseLife()
    {
        lives -= 1;
        livesText.text = lives.ToString();
    }
}
