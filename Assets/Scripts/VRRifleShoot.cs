using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRGrabInteractable))]
public class VRRifleShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform muzzlePoint;
    public float shotPower = 10f;
    public AudioClip shotSound;
    public ParticleSystem muzzleFlash;
    public Animator animator;
    private XRGrabInteractable grabInteractable;
    private bool isGripPressed = false;
    private AudioSource audioSource;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.onActivate.AddListener(StartFiring);
        grabInteractable.onDeactivate.AddListener(StopFiring);

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();
    }

    private void OnDestroy()
    {
        grabInteractable.onActivate.RemoveListener(StartFiring);
        grabInteractable.onDeactivate.RemoveListener(StopFiring);
    }

    private void StartFiring(XRBaseInteractor interactor)
    {
        if (!isGripPressed)
        {
            isGripPressed = true;
            StartCoroutine(FireContinuously());
        }
    }

    private void StopFiring(XRBaseInteractor interactor)
    {
        isGripPressed = false;
    }

    private IEnumerator FireContinuously()
    {
        while (isGripPressed)
        {
            Fire();
            yield return null; // 한 프레임을 기다립니다. 적절한 딜레이를 조절하십시오.
        }
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