using UnityEngine;
using System.Collections;

public class CloneGenerator : MonoBehaviour
{

    // ������ ��� ������������
    public GameObject clonePrefab;
    // 2D ������, ������� �������� ����� ������������ ��� ���������
    public GameObject spawnRangeObject; 
    // �������� ����� ��������� ������
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
        // �������� ������� 2D �������
        Renderer rangeRenderer = spawnRangeObject.GetComponent<Renderer>();
        Bounds rangeBounds = rangeRenderer.bounds;

        // ������� ����� ��������� (����) ������� � ��������� �������� � �������� ������
        float randomX = Random.Range(rangeBounds.min.x, rangeBounds.max.x);
        float randomY = Random.Range(rangeBounds.min.y, rangeBounds.max.y);
        Vector3 randomPosition = new Vector3(randomX, randomY, 0f);

        Instantiate(clonePrefab, randomPosition, Quaternion.identity);
    }
}
