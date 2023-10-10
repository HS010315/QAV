using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;


public class ScoreManager2 : MonoBehaviour
{
    public static ScoreManager2 Instance { get; private set; }

    public Text scoreText; // 스코어를 표시할 UI 텍스트

    private int currentScore = 0;

    private XRGrabInteractable grabInteractable; // VR 상호작용 컴포넌트

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        grabInteractable = GetComponent<XRGrabInteractable>(); // XRGrabInteractable 컴포넌트 할당
    }
    private void Start()
    {
        UpdateScoreText();
    }
     private void OnSelectEntered(XRBaseInteractor interactor)
    {
        // 점수 증가
        AddScore(1);
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