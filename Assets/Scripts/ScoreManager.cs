using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    public Text scoreText; // ������ ǥ���� UI �ؽ�Ʈ

    private int score = 0; // ���� ����

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
        grabInteractable.onSelectEntered.AddListener(OnSelectEntered);
    }

    private void OnDestroy()
    {
        if (grabInteractable != null && grabInteractable.onSelectEntered != null)
        {
            grabInteractable.onSelectEntered.RemoveListener(OnSelectEntered);
        }
    }
    private void OnSelectEntered(XRBaseInteractor interactor)
    {
        // ���� ����
        AddScore(1);
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void ResetScore()
    {
        score = 0;
        UpdateScoreText();
    }
}