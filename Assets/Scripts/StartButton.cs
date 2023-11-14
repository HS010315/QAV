using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    private TargetGenerator targetGenerator;
    public ScoreManager scoreManager;
    public Text text;

    private bool isHit = false;

    public void Initialize(TargetGenerator generator)
    {
        targetGenerator = generator;
    }

    private void Update()
    {
        if (isHit)
        {
            StartCoroutine(StartButtonAction());
            isHit = false; // �� ���� ����ǵ��� �÷��׸� �ٽ� false�� ����
            text.gameObject.SetActive(false);
        }
    }

    private IEnumerator StartButtonAction()
    {
        // �Ѿ˿� ���� �� 2�� ���
        yield return new WaitForSeconds(2f);

        // 2�� �ڿ� ������ �۾� ����
        targetGenerator.RestartGeneration();
        scoreManager.ResetScore();
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            isHit = true; // �Ѿ˿� ������ �÷��׸� true�� ����
        }
    }
}