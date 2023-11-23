using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class MountainSwitcher : MonoBehaviour
{
    public Image transitionImage;
    public float imageDuration = 3.0f;
    public string sceneToLoad = "Mountain"; // 要加载的场景名称

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // 确保玩家标签是"Player"
        {
            StartCoroutine(TransitionRoutine());
        }
    }

    IEnumerator TransitionRoutine()
    {
        transitionImage.gameObject.SetActive(true); // 显示图片
        yield return new WaitForSeconds(imageDuration); // 等待3秒
        transitionImage.gameObject.SetActive(false); // 隐藏图片

        SceneManager.LoadScene(sceneToLoad); // 加载场景
    }
}
