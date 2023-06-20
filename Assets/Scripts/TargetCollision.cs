using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TargetCollision : MonoBehaviour
{
    private TargetGenerator targetGenerator;
  //  private AudioSource audioSource;

  //  public AudioClip hitSound;  // �Ѿ˿� �¾��� �� ����� �Ҹ�

    public void Initialize(TargetGenerator generator)
    {
        targetGenerator = generator;
    //    audioSource = GetComponent<AudioSource>();
     //   if (audioSource == null)
    //        audioSource = gameObject.AddComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
         //   audioSource.PlayOneShot(hitSound);  // �Ҹ� ���
            targetGenerator.DestroyTarget(gameObject);
        }
    }
}