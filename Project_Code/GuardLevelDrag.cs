using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;

public class GuardLevelDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector2 originalPosition;
    private RectTransform rectTransform;
    private Canvas canvas;
    public GameObject guardImage;
    public RectTransform targetRectTransform; // 守卫的 RectTransform
    public GameObject successImage;           // 成功的 Image
    public GameObject failImage;              // 失败的 Image
    public string itemType;                   // UI 元素类型（例如："Gold"）

    void Awake()
    {   
        rectTransform = GetComponent<RectTransform>();
        canvas = FindObjectOfType<Canvas>();
        successImage.SetActive(false);
        failImage.SetActive(false);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalPosition = rectTransform.anchoredPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {   


        if (RectTransformUtility.RectangleContainsScreenPoint(
            targetRectTransform, eventData.position, eventData.pressEventCamera))
        {    
            CheckDragResult();
            ToggleGuardImage();
        }
        else
        {
            rectTransform.anchoredPosition = originalPosition;
        }
    }

    private void CheckDragResult()
    {
        if (itemType == "Gold")
        {
            StartCoroutine(ShowResultAndSwitchScene(successImage, true));
        }
        else
        {
            StartCoroutine(ShowResultAndSwitchScene(failImage, false));
        }
    }
    private void ToggleGuardImage()
    {
        // 切换守卫 Image 的显示状态
        guardImage.SetActive(!guardImage.activeSelf);
    }

    private IEnumerator ShowResultAndSwitchScene(GameObject image, bool levelComplete)
    {
        image.SetActive(true);
        yield return new WaitForSeconds(2);
        image.SetActive(false);

        if (levelComplete)
        {
            GameManagement.Instance.IsFifthLevelComplete = true; // 标记第五关完成
        }

        SceneManager.LoadScene("MainScene");
    }
}
