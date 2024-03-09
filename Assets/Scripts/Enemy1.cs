using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float speed = 5f; // �������� �������� �������

    void Update()
    {
        // �������� ������� ���������� �������
        Vector3 currentPosition = transform.position;
        // ��������� ����� ���������� � ������ ������������� �������� � ������� �����
        float newX = currentPosition.x - speed * Time.deltaTime;
        // ��������� ������� �������
        transform.position = new Vector3(newX, currentPosition.y, currentPosition.z);
    }
}
