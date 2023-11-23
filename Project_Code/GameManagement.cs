using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagement : MonoBehaviour
{
    public static GameManagement Instance { get; private set; }

    public bool IsThirdLevelComplete { get; set; }

    public bool IsFourthLevelComplete { get; set; }

    public bool IsFifthLevelComplete { get; set; }

    // 存储所有玩家预制体（包含摄像机作为子对象）
    public GameObject[] playerPrefabs;
    private GameObject[] playerInstances;
    // 当前激活的玩家
    private GameObject currentPlayer;


    public GameObject doughUI; // 面团的UI

    public GameObject fishUI;  // 鱼的UI

    public GameObject goldUI;  // 元宝的UI

    public bool isDoughUIActive;

    public bool isFishUIActive;

    public bool isGoldUIActive;

    public void SwitchPlayer(int sceneIndex)
    {
        // 隐藏当前玩家
        if (currentPlayer != null)
        {
            currentPlayer.SetActive(false);
        }

        // 检查是否已经实例化过这个玩家
        if (playerPrefabs[sceneIndex] != null)
        {
            currentPlayer = playerPrefabs[sceneIndex];
            currentPlayer.SetActive(true); // 激活新玩家
            SetPlayerToSpawnPoint();
        }
        else
        {
            // 如果尚未实例化，创建新玩家
            currentPlayer = Instantiate(playerPrefabs[sceneIndex]);
            SetPlayerToSpawnPoint();
        }
    }

    void Update()
    {
        if (doughUI != null)
        {
            isDoughUIActive = doughUI.activeSelf;
        }

        if (fishUI != null)
        {
            isFishUIActive = fishUI.activeSelf;
        }

        if (goldUI != null)
        {
            isGoldUIActive = goldUI.activeSelf;
        }
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            playerInstances = new GameObject[playerPrefabs.Length];
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void SetPlayerToSpawnPoint()
    {
        GameObject spawnPoint = GameObject.FindWithTag("SpawnPoint");
        if (spawnPoint != null && currentPlayer != null)
        {
            currentPlayer.transform.position = spawnPoint.transform.position;
            currentPlayer.transform.rotation = spawnPoint.transform.rotation;
            Debug.Log("Player spawned at: " + spawnPoint.transform.position);
            // 如果使用Rigidbody，确保不要休眠
            Rigidbody rb = currentPlayer.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.WakeUp();
            }
        }
        else
        {
            Debug.LogWarning("SpawnPoint not found. Player will be instantiated at the origin.");
        }
    }
}
