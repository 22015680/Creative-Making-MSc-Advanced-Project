using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject uiPanel; // UI面板引用
    public Camera playerCamera; // 玩家摄像机引用

    void Start()
    {
        // 初始时禁用玩家摄像机
        if (playerCamera != null)
        {
            playerCamera.enabled = false;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            uiPanel.SetActive(false); // 隐藏UI
            EnablePlayerCamera(); // 启用玩家摄像机
        }
    }

    void EnablePlayerCamera()
    {
        if (playerCamera != null)
        {
            playerCamera.enabled = true;
        }
    }
}