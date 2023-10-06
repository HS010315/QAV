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
            // 총알이 어떤 부위에 충돌했는지 확인
            ContactPoint contact = collision.contacts[0];
            Collider collider = contact.otherCollider;

            // 충돌한 부위에 따라 점수 부여
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