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
            // 총알이 어떤 부위에 충돌했는지 확인
            ContactPoint contact = collision.contacts[0];
            Collider collider = contact.otherCollider;

            // 충돌한 부위에 따라 점수 부여
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