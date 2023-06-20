using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    private TargetGenerator targetGenerator;
    public ScoreManager scoreManager;

    public void Initialize(TargetGenerator generator)
    {
        targetGenerator = generator;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            targetGenerator.RestartGeneration();
            scoreManager.ResetScore();
        }
    }
}