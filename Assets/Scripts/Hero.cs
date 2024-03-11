using UnityEngine;

public class GridMovement : MonoBehaviour
{
    public float gridSize = 1.0f; // ������ ����
    public int health = 5; // ������ ����

    // ������� ������
    public Canvas canvasToToggle;

    public float distanceFromPlayer = 0.5f; // ���������� �� ������ �� �������������� �������
    public LayerMask blockingLayer; // ����, �� ������� ��������� �����
    public GameObject[] objectPrefabs; // ������� �������� �� 1 �� 5

    private BoxCollider2D playerCollider;

    private void Start()
    {
        playerCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {

        // ���������� ������
        if (health <= 0)
        {
            canvasToToggle.enabled = true;
        }
        else
        {
            canvasToToggle.enabled = false;
        }


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

        for (int i = 1; i <= 5; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha0 + i))
            {
                SetObject(i);
            }
        }
    }

    void SetObject(int objectIndex)
    {
        // ���������, ��� ������ ������� � ���������� ���������
        if (objectIndex >= 1 && objectIndex <= objectPrefabs.Length)
        {
            // ������� ��������� ������� ����� ������� � ������ ����������
            Vector3 spawnPosition = transform.position + transform.right * (gridSize + distanceFromPlayer);

            // ���������, ���� �� ������ � ����� �������
            Collider2D hitCollider = Physics2D.OverlapBox(spawnPosition, new Vector2(objectPrefabs[objectIndex - 1].transform.localScale.x, objectPrefabs[objectIndex - 1].transform.localScale.y), 0, blockingLayer);

            // ���� ��� ������������, ������� ������
            if (hitCollider == null)
            {
                Instantiate(objectPrefabs[objectIndex - 1], spawnPosition, Quaternion.identity);
            }
        }
    }

    void Move(Vector3 direction)
    {
        // ���������� ����� ������� � ������ ������� ���� � �������� ������
        Vector3 newPosition = transform.position + direction * gridSize;

        // ������������ ���������� � �������� ������, �������� ������� ������
        float minX = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + playerCollider.bounds.extents.x;
        float maxX = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - playerCollider.bounds.extents.x;
        float minY = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + playerCollider.bounds.extents.y;
        float maxY = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - playerCollider.bounds.extents.y;

        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

        // ���������, ���� �� ������ � ����� �������
        Collider2D hitCollider = Physics2D.OverlapBox(newPosition, new Vector2(playerCollider.bounds.size.x, playerCollider.bounds.size.y), 0, blockingLayer);

        // ���� ��� ������������, ���������� ������
        if (hitCollider == null)
        {
            transform.position = newPosition;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // ���������, ���������� �� ������ � ���-�� �� ������������ ����
        if (blockingLayer == (blockingLayer | (1 << other.gameObject.layer)))
        {
            // ���������� ���� ��� �����
            Destroy(other.gameObject);
        }
    }
}
