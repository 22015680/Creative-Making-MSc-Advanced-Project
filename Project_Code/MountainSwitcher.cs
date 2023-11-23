using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class MountainSwitcher : MonoBehaviour
{
    public Image transitionImage;
    public float imageDuration = 3.0f;
    public string sceneToLoad = "Mountain"; // Ҫ���صĳ�������

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // ȷ����ұ�ǩ��"Player"
        {
            StartCoroutine(TransitionRoutine());
        }
    }

    IEnumerator TransitionRoutine()
    {
        transitionImage.gameObject.SetActive(true); // ��ʾͼƬ
        yield return new WaitForSeconds(imageDuration); // �ȴ�3��
        transitionImage.gameObject.SetActive(false); // ����ͼƬ

        SceneManager.LoadScene(sceneToLoad); // ���س���
    }
}
