using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    public GameObject target10M; // 10M 과녁 GameObject
    public GameObject target20M; // 20M 과녁 GameObject


    private void Start()
    {
        DeactivateTarget(target10M);
        ActivateTarget(target20M);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 충돌한 객체가 총알인지 확인
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // 총알이 10M 큐브에 맞았을 경우
            if (this.gameObject.tag =="10M")
            {
               Debug.Log("10m");
                // 10M 과녁 활성화, 20M 과녁 비활성화
                ActivateTarget(target10M);
                DeactivateTarget(target20M);
            }
            // 총알이 20M 큐브에 맞았을 경우
            else if (this.gameObject.tag =="20M")
            {
                Debug.Log("20m");
                // 20M 과녁 활성화, 10M 과녁 비활성화
                ActivateTarget(target20M);
                DeactivateTarget(target10M);
            }

        }
    }

    private void ActivateTarget(GameObject target)
    {
        // 과녁을 활성화하는 함수
        target.SetActive(true);
    }

    private void DeactivateTarget(GameObject target)
    {
        // 과녁을 비활성화하는 함수
        target.SetActive(false);
    }
}