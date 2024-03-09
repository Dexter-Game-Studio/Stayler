using UnityEngine;

public class EnemyRemovalScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // ���������, ���� ������������� ������ ����� ��� "Enemy" ��� "bullet"
        if (other.CompareTag("Enemy") || other.CompareTag("bullet"))
        {
            // ������� ������������� ������
            Destroy(other.gameObject);
        }
    }
}
