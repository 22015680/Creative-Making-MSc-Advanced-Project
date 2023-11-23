using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public static SceneManagement Instance { get; private set; }

    void Start()
    {
        // 根据当前场景的索引切换玩家（和摄像机）
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        GameManagement.Instance.SwitchPlayer(sceneIndex);
    }
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
