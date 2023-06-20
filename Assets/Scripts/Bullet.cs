using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifetime = 2f;  // 총알의 수명

    public GameObject particlePrefab; // 파티클 프리팹


    private void Start()
    {
        Invoke("DestroyBullet", lifetime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            // 파티클 프리팹을 인스턴스화하여 맞은 위치에서 재생시킴
            GameObject particle = Instantiate(particlePrefab, collision.contacts[0].point, Quaternion.identity);
            ParticleSystem particleSystem = particle.GetComponent<ParticleSystem>();
            Destroy(particle, particleSystem.main.duration); // 파티클 재생이 끝난 후에 파괴되도록 설정

            DestroyBullet();
        }
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
    }
}