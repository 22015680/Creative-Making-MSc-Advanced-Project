using UnityEngine;
using System.Collections;

public class CollisionHint : MonoBehaviour
{
    public GameObject hintImage; // 提示Image的引用

    private void Start()
    {
        // 确保提示Image初始时是隐藏的
        hintImage.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // 确保标签是 "Player"
        {
            StartCoroutine(ShowHint());
        }
    }

    private IEnumerator ShowHint()
    {
        hintImage.SetActive(true); // 显示提示Image
        yield return new WaitForSeconds(3); // 等待三秒
        hintImage.SetActive(false); // 隐藏提示Image
    }
}