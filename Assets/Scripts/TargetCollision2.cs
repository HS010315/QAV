using UnityEngine;

public class TargetCollision2 : MonoBehaviour
{
    public int headshotScore = 10;
    public int bodyshotScore = 5;
    public int legshotScore = 2;

    private ScoreManager scoreManager;

    public void Initialize(ScoreManager manager)
    {
        scoreManager = manager;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // �Ѿ��� � ������ �浹�ߴ��� Ȯ��
            ContactPoint contact = collision.contacts[0];
            Collider collider = contact.otherCollider;

            // �浹�� ������ ���� ���� �ο�
            if (collider.CompareTag("Head"))
            {
                scoreManager.AddScore(headshotScore);
            }
            else if (collider.CompareTag("Body"))
            {
                scoreManager.AddScore(bodyshotScore);
            }
            else if (collider.CompareTag("Legs"))
            {
                scoreManager.AddScore(legshotScore);
            }


        }
    }
}