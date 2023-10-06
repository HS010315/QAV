using UnityEngine;
using UnityEngine.UI;

public class ScoreManager2 : MonoBehaviour
{
    public Text scoreText; // 스코어를 표시할 UI 텍스트

    private int currentScore = 0;

    private void Start()
    {
        UpdateScoreText();
    }

    public void AddScore(int score)
    {
        currentScore += score;
        UpdateScoreText();
    }

    public void SubtractScore(int score)
    {
        currentScore -= score;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        // UI 텍스트 업데이트
        if (scoreText != null)
        {
            scoreText.text = "Score: " + currentScore.ToString();
        }
    }
}