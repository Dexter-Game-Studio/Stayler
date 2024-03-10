using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
public class PlayerMovement : MonoBehaviour
{
    public float gridSize = 1f; // ������ ������ �����
    private bool isMoving = false;
    private Vector3 targetPosition;

    public float width, height;


    void Update()
    {
        if (!isMoving)
        {
            // ��������� ����� �� ������
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            // �������� ����� � ����������� �� �����
            if (horizontalInput != 0 || verticalInput != 0)
            {
                Move(horizontalInput, verticalInput);
            }
        }
    }

    void Move(float horizontal, float vertical)
    {
        // ���������� ����� ������� ����
        targetPosition = new Vector3(
            Mathf.Round(transform.position.x / gridSize) * gridSize + gridSize * horizontal,
            Mathf.Round(transform.position.y / gridSize) * gridSize + gridSize * vertical,
            transform.position.z
        );

        // ��������, �� ������� �� ���� �� ������� �����
        if (IsValidMove(targetPosition))
        {
            // ������ �������� ��� �������� �����������
            StartCoroutine(MoveToTarget());
        }
    }

    bool IsValidMove(Vector3 targetPos)
    {

        // �������� ��������� �� ����� ������� � �������� �����
        return Mathf.Abs(targetPos.x) < gridSize * (width / 2) &&
               Mathf.Abs(targetPos.y) < gridSize * (height / 2);
    }

    IEnumerator MoveToTarget()
    {
        isMoving = true;

        // ������� ����������� � ����
        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, 5f * Time.deltaTime);
            yield return null;
        }

        // ���������� ��������
        transform.position = targetPosition;
        isMoving = false;
    }
}
