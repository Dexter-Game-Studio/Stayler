using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
public class PlayerMovement : MonoBehaviour
{
    public float gridSize = 1f; // Размер ячейки сетки
    private bool isMoving = false;
    private Vector3 targetPosition;

    public float width, height;


    void Update()
    {
        if (!isMoving)
        {
            // Обработка ввода от игрока
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            // Проверка ввода и перемещение по сетке
            if (horizontalInput != 0 || verticalInput != 0)
            {
                Move(horizontalInput, verticalInput);
            }
        }
    }

    void Move(float horizontal, float vertical)
    {
        // Вычисление новой позиции цели
        targetPosition = new Vector3(
            Mathf.Round(transform.position.x / gridSize) * gridSize + gridSize * horizontal,
            Mathf.Round(transform.position.y / gridSize) * gridSize + gridSize * vertical,
            transform.position.z
        );

        // Проверка, не выходит ли цель за пределы сетки
        if (IsValidMove(targetPosition))
        {
            // Запуск корутины для плавного перемещения
            StartCoroutine(MoveToTarget());
        }
    }

    bool IsValidMove(Vector3 targetPos)
    {

        // Проверка находится ли новая позиция в пределах сетки
        return Mathf.Abs(targetPos.x) < gridSize * (width / 2) &&
               Mathf.Abs(targetPos.y) < gridSize * (height / 2);
    }

    IEnumerator MoveToTarget()
    {
        isMoving = true;

        // Плавное перемещение к цели
        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, 5f * Time.deltaTime);
            yield return null;
        }

        // Завершение движения
        transform.position = targetPosition;
        isMoving = false;
    }
}
