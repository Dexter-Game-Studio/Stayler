using UnityEngine;
using System.Collections;

public class CloneGenerator : MonoBehaviour
{

    // Префаб для клонирования
    public GameObject clonePrefab;
    // 2D объект, границы которого будут использованы для диапазона
    public GameObject spawnRangeObject; 
    // Интервал между созданием клонов
    public float spawnInterval = 2f; 

    void Start()
    {
        StartCoroutine(SpawnClonesWithInterval());
    }

    IEnumerator SpawnClonesWithInterval()
    {
        while (true)
        {
            GenerateClone();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void GenerateClone()
    {
        // Получаем границы 2D объекта
        Renderer rangeRenderer = spawnRangeObject.GetComponent<Renderer>();
        Bounds rangeBounds = rangeRenderer.bounds;

        // Создаем новый экземпляр (клон) объекта с случайной позицией в пределах границ
        float randomX = Random.Range(rangeBounds.min.x, rangeBounds.max.x);
        float randomY = Random.Range(rangeBounds.min.y, rangeBounds.max.y);
        Vector3 randomPosition = new Vector3(randomX, randomY, 0f);

        Instantiate(clonePrefab, randomPosition, Quaternion.identity);
    }
}
