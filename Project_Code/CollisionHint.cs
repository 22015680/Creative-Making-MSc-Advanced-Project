using UnityEngine;
using System.Collections;

public class CollisionHint : MonoBehaviour
{
    public GameObject hintImage; // ��ʾImage������

    private void Start()
    {
        // ȷ����ʾImage��ʼʱ�����ص�
        hintImage.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // ȷ����ǩ�� "Player"
        {
            StartCoroutine(ShowHint());
        }
    }

    private IEnumerator ShowHint()
    {
        hintImage.SetActive(true); // ��ʾ��ʾImage
        yield return new WaitForSeconds(3); // �ȴ�����
        hintImage.SetActive(false); // ������ʾImage
    }
}