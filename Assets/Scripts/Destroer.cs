using UnityEngine;

public class EnemyRemovalScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Проверяем, если столкнувшийся объект имеет тег "Enemy" или "bullet"
        if (other.CompareTag("Enemy") || other.CompareTag("bullet"))
        {
            // Удаляем столкнувшийся объект
            Destroy(other.gameObject);
        }
    }
}
