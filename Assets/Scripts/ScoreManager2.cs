using UnityEngine;
using UnityEngine.UI;

public class ScoreManager2 : MonoBehaviour
{
    public Text scoreText; // ���ھ ǥ���� UI �ؽ�Ʈ

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
        // UI �ؽ�Ʈ ������Ʈ
        if (scoreText != null)
        {
            scoreText.text = "Score: " + currentScore.ToString();
        }
    }
}