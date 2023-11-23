using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SchoolTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // 确保只有带有"Player"标签的对象触发场景转换
        {
            SceneManager.LoadScene("School"); // 将场景名称替换为您的学校场景名称
        }
    }
}