using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SchoolTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // ȷ��ֻ�д���"Player"��ǩ�Ķ��󴥷�����ת��
        {
            SceneManager.LoadScene("School"); // �����������滻Ϊ����ѧУ��������
        }
    }
}