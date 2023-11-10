using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    public GameObject target10M; // 10M ���� GameObject
    public GameObject target20M; // 20M ���� GameObject


    private void Start()
    {
        DeactivateTarget(target10M);
        ActivateTarget(target20M);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // �浹�� ��ü�� �Ѿ����� Ȯ��
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // �Ѿ��� 10M ť�꿡 �¾��� ���
            if (this.gameObject.tag =="10M")
            {
               Debug.Log("10m");
                // 10M ���� Ȱ��ȭ, 20M ���� ��Ȱ��ȭ
                ActivateTarget(target10M);
                DeactivateTarget(target20M);
            }
            // �Ѿ��� 20M ť�꿡 �¾��� ���
            else if (this.gameObject.tag =="20M")
            {
                Debug.Log("20m");
                // 20M ���� Ȱ��ȭ, 10M ���� ��Ȱ��ȭ
                ActivateTarget(target20M);
                DeactivateTarget(target10M);
            }

        }
    }

    private void ActivateTarget(GameObject target)
    {
        // ������ Ȱ��ȭ�ϴ� �Լ�
        target.SetActive(true);
    }

    private void DeactivateTarget(GameObject target)
    {
        // ������ ��Ȱ��ȭ�ϴ� �Լ�
        target.SetActive(false);
    }
}