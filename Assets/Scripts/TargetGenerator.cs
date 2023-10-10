using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetGenerator : MonoBehaviour
{
    public GameObject targetPrefab;
    public Transform[] targetPositions;
    public float spawnInterval = 1f;
    public int numTargets = 20;
    public float targetLifetime = 2f;
    public float waitforStart = 2f;
    private float timer = 0f;
    private int generatedCount = 0;

    private Coroutine generationCoroutine;

    private void Start()
    {
        StartGeneration();
    }

    private void StartGeneration()
    {
        if (generationCoroutine == null)
        {
            generationCoroutine = StartCoroutine(GenerateTargets());
        }
    }

    private IEnumerator GenerateTargets()
    {
        while (generatedCount < numTargets)
        {
            yield return new WaitForSeconds(waitforStart);

            int randomIndex = Random.Range(0, targetPositions.Length);
            Vector3 spawnPosition = targetPositions[randomIndex].position;
            Quaternion spawnRotation = Quaternion.Euler(0f, 0f, 90f);
            GameObject target = Instantiate(targetPrefab, spawnPosition, spawnRotation);

            TargetCollision targetCollision = target.GetComponent<TargetCollision>();  
            if (targetCollision == null)
                targetCollision = target.AddComponent<TargetCollision>();

            targetCollision.Initialize(this);

            Destroy(target, targetLifetime);

            generatedCount++;

            yield return new WaitForSeconds(spawnInterval);
        }

        generationCoroutine = null;
    }

    public void DestroyTarget(GameObject target)
    {
        Destroy(target);
    }

    public void RestartGeneration()
    {
        if (generationCoroutine != null)
        {
            StopCoroutine(generationCoroutine);
            generationCoroutine = null;
        }

        generatedCount = 0;
        StartGeneration();
    }
}