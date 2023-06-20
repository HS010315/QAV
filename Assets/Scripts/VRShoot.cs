using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRGrabInteractable))]
public class VRShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform muzzlePoint;
    public float shotPower = 10f;
    public AudioClip shotSound;
    public ParticleSystem muzzleFlash;
    public Animator animator;
    private XRGrabInteractable grabInteractable;
    private bool hasFired = false;
    private AudioSource audioSource;

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
        if (!hasFired)
        {
            Fire();
            hasFired = true;
        }
    }

    private void OnGripReleased(XRBaseInteractor interactor)
    {
        hasFired = false;
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