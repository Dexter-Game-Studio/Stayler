using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float speed = 5f; // Скорость движения объекта

    void Update()
    {
        // Получаем текущие координаты объекта
        Vector3 currentPosition = transform.position;
        // Вычисляем новые координаты с учетом отрицательной скорости и времени кадра
        float newX = currentPosition.x - speed * Time.deltaTime;
        // Обновляем позицию объекта
        transform.position = new Vector3(newX, currentPosition.y, currentPosition.z);
    }
}
