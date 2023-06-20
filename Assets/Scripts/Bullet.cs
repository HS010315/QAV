using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifetime = 2f;  // �Ѿ��� ����

    public GameObject particlePrefab; // ��ƼŬ ������


    private void Start()
    {
        Invoke("DestroyBullet", lifetime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            // ��ƼŬ �������� �ν��Ͻ�ȭ�Ͽ� ���� ��ġ���� �����Ŵ
            GameObject particle = Instantiate(particlePrefab, collision.contacts[0].point, Quaternion.identity);
            ParticleSystem particleSystem = particle.GetComponent<ParticleSystem>();
            Destroy(particle, particleSystem.main.duration); // ��ƼŬ ����� ���� �Ŀ� �ı��ǵ��� ����

            DestroyBullet();
        }
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
    }
}