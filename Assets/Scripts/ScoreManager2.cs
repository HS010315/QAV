using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;


public class ScoreManager2 : MonoBehaviour
{
    public static ScoreManager2 Instance { get; private set; }

    public Text scoreText; // ���ھ ǥ���� UI �ؽ�Ʈ

    private int currentScore = 0;

    private XRGrabInteractable grabInteractable; // VR ��ȣ�ۿ� ������Ʈ

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        grabInteractable = GetComponent<XRGrabInteractable>(); // XRGrabInteractable ������Ʈ �Ҵ�
    }
    private void Start()
    {
        UpdateScoreText();
    }
     private void OnSelectEntered(XRBaseInteractor interactor)
    {
        // ���� ����
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
        // UI �ؽ�Ʈ ������Ʈ
        if (scoreText != null)
        {
            scoreText.text = "Score: " + currentScore.ToString();
        }
    }
}