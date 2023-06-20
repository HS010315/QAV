using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int scoreValue = 1;  // Ÿ���� ������ �� ������ ����

    private void OnCollisionEnter(Collision collision)
    {
        // �浹�� ��ü�� �÷��̾����� Ȯ��
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // ���� ����
            ScoreManager.Instance.AddScore(scoreValue);

            // Ÿ�� ������Ʈ ��Ȱ��ȭ
            gameObject.SetActive(false);
        }
    }
}