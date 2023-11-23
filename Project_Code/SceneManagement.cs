using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public static SceneManagement Instance { get; private set; }

    void Start()
    {
        // ���ݵ�ǰ�����������л���ң����������
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
