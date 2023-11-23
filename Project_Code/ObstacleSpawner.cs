using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float initialSpawnInterval = 2.0f; // 初始生成间隔
    public float maxSpawnRateIncrease = 0.05f; // 生成频率的最大增加速度
    private float spawnInterval; // 当前生成间隔
    private float timer;
    private float screenTop;
    private float screenBottom;
    private float safeZone = 1.5f; // 安全区域的高度
    private bool spawnAtTop = true; // 下一次是否在顶部生成

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
        spawnInterval = Mathf.Max(spawnInterval, 0.5f); // 限制最小间隔时间

        if (timer >= spawnInterval)
        {
            SpawnObstacle();
            timer = 0f;
            spawnAtTop = !spawnAtTop; // 下次生成位置交替
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