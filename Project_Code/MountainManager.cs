using UnityEngine;
using UnityEngine.SceneManagement;

public class MountainManager : MonoBehaviour
{
    public GameObject player; // 场景中的玩家对象
    public Camera mountainCamera; // 场景中的摄像机

    void Start()
    {
        InitializeLevel();
    }

    void InitializeLevel()
    {
        // 激活玩家和摄像机
        if (player != null)
        {
            player.SetActive(true);
        }

        if (mountainCamera != null)
        {
            mountainCamera.gameObject.SetActive(true);
        }

        // 这里可以添加其他关卡初始化逻辑
    }

    
}
