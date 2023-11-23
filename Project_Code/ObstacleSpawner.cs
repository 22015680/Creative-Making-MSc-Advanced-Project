using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float initialSpawnInterval = 2.0f; // ��ʼ���ɼ��
    public float maxSpawnRateIncrease = 0.05f; // ����Ƶ�ʵ���������ٶ�
    private float spawnInterval; // ��ǰ���ɼ��
    private float timer;
    private float screenTop;
    private float screenBottom;
    private float safeZone = 1.5f; // ��ȫ����ĸ߶�
    private bool spawnAtTop = true; // ��һ���Ƿ��ڶ�������

    void Start()
    {
        spawnInterval = initialSpawnInterval;
        screenTop = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
        screenBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;
    }

    void Update()
    {
        timer += Time.deltaTime;
        spawnInterval -= maxSpawnRateIncrease * Time.deltaTime;
        spawnInterval = Mathf.Max(spawnInterval, 0.5f); // ������С���ʱ��

        if (timer >= spawnInterval)
        {
            SpawnObstacle();
            timer = 0f;
            spawnAtTop = !spawnAtTop; // �´�����λ�ý���
        }
    }

    void SpawnObstacle()
    {
        float obstacleHeight = spawnAtTop
            ? Random.Range(screenTop - safeZone, screenTop)
            : Random.Range(screenBottom, screenBottom + safeZone);

        Instantiate(obstaclePrefab, new Vector3(10, obstacleHeight, 0), Quaternion.identity);
    }
}