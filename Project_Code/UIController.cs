using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject uiPanel; // UI�������
    public Camera playerCamera; // ������������

    void Start()
    {
        // ��ʼʱ������������
        if (playerCamera != null)
        {
            playerCamera.enabled = false;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            uiPanel.SetActive(false); // ����UI
            EnablePlayerCamera(); // ������������
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