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
            isHit = false; // 한 번만 실행되도록 플래그를 다시 false로 설정
            text.gameObject.SetActive(false);
        }
    }

    private IEnumerator StartButtonAction()
    {
        // 총알에 맞은 후 2초 대기
        yield return new WaitForSeconds(2f);

        // 2초 뒤에 실행할 작업 수행
        targetGenerator.RestartGeneration();
        scoreManager.ResetScore();
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            isHit = true; // 총알에 맞으면 플래그를 true로 설정
        }
    }
}