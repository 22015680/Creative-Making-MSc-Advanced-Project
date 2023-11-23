using UnityEngine;
using UnityEngine.SceneManagement;

public class MountainManager : MonoBehaviour
{
    public GameObject player; // �����е���Ҷ���
    public Camera mountainCamera; // �����е������

    void Start()
    {
        InitializeLevel();
    }

    void InitializeLevel()
    {
        // ������Һ������
        if (player != null)
        {
            player.SetActive(true);
        }

        if (mountainCamera != null)
        {
            mountainCamera.gameObject.SetActive(true);
        }

        // ���������������ؿ���ʼ���߼�
    }

    
}
