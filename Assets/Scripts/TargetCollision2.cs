using UnityEngine;

public class TargetCollision2 : MonoBehaviour
{
    public int headshotScore = 10;
    public int bodyshotScore = 8;
    public int legshotScore = 6;
    public int armshotScore = 4;

    private ScoreManager2 scoreManager2;

    public void Initialize(ScoreManager2 manager)
    {
        scoreManager2 = manager;
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
                scoreManager2.AddScore(headshotScore);
            }
            else if (collider.CompareTag("Body"))
            {
                scoreManager2.AddScore(bodyshotScore);
            }
            else if (collider.CompareTag("Legs"))
            {
                scoreManager2.AddScore(legshotScore);
            }
            else if (collider.CompareTag("Arms"))
            {
                scoreManager2.AddScore(armshotScore);
            }


        }
    }
}