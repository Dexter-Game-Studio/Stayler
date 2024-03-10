using UnityEngine;

public class GridMovement : MonoBehaviour
{
    public float gridSize = 1.0f; // ������ ����

    void Update()
    {
        // ����������� �� �������������� ���
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            Move(Vector3.right);
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            Move(Vector3.left);

        // ����������� �� ������������ ���
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            Move(Vector3.up);
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            Move(Vector3.down);
    }

    void Move(Vector3 direction)
    {
        // ���������� ����� ������� � ������ ������� ����
        Vector3 newPosition = transform.position + direction * gridSize;

        // ����������� ������
        transform.position = newPosition;
    }
}
