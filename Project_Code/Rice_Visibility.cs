using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rice_Visibility : MonoBehaviour
{
    // �����������������ʾ��GameObject
    public GameObject objectToShow;

    private void Start()
    {
        // ����������˵ڶ��أ���ʾ�������
        if (GameManagement.Instance != null && GameManagement.Instance.IsThirdLevelComplete)
        {
            objectToShow.SetActive(true);
        }
        else
        {
            objectToShow.SetActive(false);
        }
    }
}
