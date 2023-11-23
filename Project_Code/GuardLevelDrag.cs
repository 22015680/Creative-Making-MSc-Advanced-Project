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
    public RectTransform targetRectTransform; // ������ RectTransform
    public GameObject successImage;           // �ɹ��� Image
    public GameObject failImage;              // ʧ�ܵ� Image
    public string itemType;                   // UI Ԫ�����ͣ����磺"Gold"��

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
        // �л����� Image ����ʾ״̬
        guardImage.SetActive(!guardImage.activeSelf);
    }

    private IEnumerator ShowResultAndSwitchScene(GameObject image, bool levelComplete)
    {
        image.SetActive(true);
        yield return new WaitForSeconds(2);
        image.SetActive(false);

        if (levelComplete)
        {
            GameManagement.Instance.IsFifthLevelComplete = true; // ��ǵ�������
        }

        SceneManager.LoadScene("MainScene");
    }
}
