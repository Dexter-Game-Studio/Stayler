using UnityEngine;

public class GridMovement : MonoBehaviour
{
    public float gridSize = 1.0f; // Размер шага
    public int health = 5; // Размер шага

    // Канавас смерти
    public Canvas canvasToToggle;

    public float distanceFromPlayer = 0.5f; // Расстояние от игрока до установленного объекта
    public LayerMask blockingLayer; // Слой, на котором находятся блоки
    public GameObject[] objectPrefabs; // Префабы объектов от 1 до 5

    private BoxCollider2D playerCollider;

    private void Start()
    {
        playerCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {

        // обработчик сметри
        if (health <= 0)
        {
            canvasToToggle.enabled = true;
        }
        else
        {
            canvasToToggle.enabled = false;
        }


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
        // Проверяем, что индекс объекта в допустимом диапазоне
        if (objectIndex >= 1 && objectIndex <= objectPrefabs.Length)
        {
            // Создаем экземпляр объекта перед игроком с учетом расстояния
            Vector3 spawnPosition = transform.position + transform.right * (gridSize + distanceFromPlayer);

            // Проверяем, есть ли объект в новой позиции
            Collider2D hitCollider = Physics2D.OverlapBox(spawnPosition, new Vector2(objectPrefabs[objectIndex - 1].transform.localScale.x, objectPrefabs[objectIndex - 1].transform.localScale.y), 0, blockingLayer);

            // Если нет столкновения, создаем объект
            if (hitCollider == null)
            {
                Instantiate(objectPrefabs[objectIndex - 1], spawnPosition, Quaternion.identity);
            }
        }
    }

    void Move(Vector3 direction)
    {
        // Рассчитать новую позицию с учетом размера шага и размеров игрока
        Vector3 newPosition = transform.position + direction * gridSize;

        // Ограничиваем координаты в пределах экрана, учитывая размеры игрока
        float minX = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + playerCollider.bounds.extents.x;
        float maxX = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - playerCollider.bounds.extents.x;
        float minY = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + playerCollider.bounds.extents.y;
        float maxY = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - playerCollider.bounds.extents.y;

        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

        // Проверяем, есть ли объект в новой позиции
        Collider2D hitCollider = Physics2D.OverlapBox(newPosition, new Vector2(playerCollider.bounds.size.x, playerCollider.bounds.size.y), 0, blockingLayer);

        // Если нет столкновения, перемещаем игрока
        if (hitCollider == null)
        {
            transform.position = newPosition;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Проверяем, столкнулся ли объект с чем-то из блокирующего слоя
        if (blockingLayer == (blockingLayer | (1 << other.gameObject.layer)))
        {
            // Уничтожаем пулю или врага
            Destroy(other.gameObject);
        }
    }
}
