using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    private TargetGenerator targetGenerator;
    public ScoreManager scoreManager;

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