using UnityEngine;

public class GridMovement : MonoBehaviour
{
    public float gridSize = 1.0f; // Размер шага

    void Update()
    {
        // Перемещение по горизонтальной оси
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            Move(Vector3.right);
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            Move(Vector3.left);

        // Перемещение по вертикальной оси
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            Move(Vector3.up);
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            Move(Vector3.down);
    }

    void Move(Vector3 direction)
    {
        // Рассчитать новую позицию с учетом размера шага
        Vector3 newPosition = transform.position + direction * gridSize;

        // Переместить объект
        transform.position = newPosition;
    }
}
