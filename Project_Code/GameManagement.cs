using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagement : MonoBehaviour
{
    public static GameManagement Instance { get; private set; }

    public bool IsThirdLevelComplete { get; set; }

    public bool IsFourthLevelComplete { get; set; }

    public bool IsFifthLevelComplete { get; set; }

    // �洢�������Ԥ���壨�����������Ϊ�Ӷ���
    public GameObject[] playerPrefabs;
    private GameObject[] playerInstances;
    // ��ǰ��������
    private GameObject currentPlayer;


    public GameObject doughUI; // ���ŵ�UI

    public GameObject fishUI;  // ���UI

    public GameObject goldUI;  // Ԫ����UI

    public bool isDoughUIActive;

    public bool isFishUIActive;

    public bool isGoldUIActive;

    public void SwitchPlayer(int sceneIndex)
    {
        // ���ص�ǰ���
        if (currentPlayer != null)
        {
            currentPlayer.SetActive(false);
        }

        // ����Ƿ��Ѿ�ʵ������������
        if (playerPrefabs[sceneIndex] != null)
        {
            currentPlayer = playerPrefabs[sceneIndex];
            currentPlayer.SetActive(true); // ���������
            SetPlayerToSpawnPoint();
        }
        else
        {
            // �����δʵ���������������
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
            // ���ʹ��Rigidbody��ȷ����Ҫ����
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
