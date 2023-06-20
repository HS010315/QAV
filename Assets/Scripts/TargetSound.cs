using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class TargetSound : MonoBehaviour
{
    public AudioClip hitSound;

    private AudioSource audioSource;

    public ParticleSystem particleSystem;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.clip = hitSound;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            PlayHitSound();
            Vector3 collisonPoint = collision.contacts[0].point;
            particleSystem.transform.position = collisonPoint;
            particleSystem.Play();
        }
    }

    private void PlayHitSound()
    {
        audioSource.PlayOneShot(hitSound);
    }
}