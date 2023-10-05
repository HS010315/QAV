using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRGrabInteractable))]
public class Sector2Pistol : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform muzzlePoint;
    public float shotPower = 10f;
    public AudioClip shotSound;
    public ParticleSystem muzzleFlash;
    public Animator animator;
    private XRGrabInteractable grabInteractable;
    private AudioSource audioSource;
    private int bulletsLeft = 3;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.onActivate.AddListener(OnGripPressed);
        grabInteractable.onDeactivate.AddListener(OnGripReleased);

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();
    }

    private void OnDestroy()
    {
        grabInteractable.onActivate.RemoveListener(OnGripPressed);
        grabInteractable.onDeactivate.RemoveListener(OnGripReleased);
    }

    private void OnGripPressed(XRBaseInteractor interactor)
    {
        if (bulletsLeft > 0)
        {
            Fire();
            bulletsLeft--;
        }
    }

    private void OnGripReleased(XRBaseInteractor interactor)
    {
        // Add any logic you want to perform when grip is released
    }

    private void Fire()
    {
        if (bulletPrefab && muzzlePoint)
        {
            GameObject bullet = Instantiate(bulletPrefab, muzzlePoint.position, muzzlePoint.rotation);
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
            bulletRigidbody.velocity = muzzlePoint.forward * shotPower;

            if (muzzleFlash != null)
                StartCoroutine(PlayMuzzleFlash());

            if (shotSound)
                audioSource.PlayOneShot(shotSound);

            if (animator != null)
                animator.SetTrigger("Shoot");
        }
    }

    private IEnumerator PlayMuzzleFlash()
    {
        muzzleFlash.Play();
        yield return new WaitForSeconds(muzzleFlash.main.duration);
        muzzleFlash.Stop();
    }
}
