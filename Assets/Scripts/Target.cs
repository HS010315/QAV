using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int scoreValue = 1;  // 타겟을 맞췄을 때 증가할 점수

    private void OnCollisionEnter(Collision collision)
    {
        // 충돌한 객체가 플레이어인지 확인
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // 점수 증가
            ScoreManager.Instance.AddScore(scoreValue);

            // 타겟 오브젝트 비활성화
            gameObject.SetActive(false);
        }
    }
}