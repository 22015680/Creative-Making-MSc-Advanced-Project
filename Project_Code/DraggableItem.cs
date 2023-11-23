using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement; 

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector2 originalPosition;
    private RectTransform rectTransform;
    private Canvas canvas;
    public RectTransform fishRodRectTransform;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = FindObjectOfType<Canvas>();
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
            fishRodRectTransform, eventData.position, eventData.pressEventCamera))
        {
            OnSuccessfulDrag();
        }
        else
        {
            rectTransform.anchoredPosition = originalPosition;
        }
    }

    private void OnSuccessfulDrag()
    {
        gameObject.SetActive(false); // 隐藏面团的UI元素
        GameManagement.Instance.IsFourthLevelComplete = true;
        SceneManager.LoadScene("MainScene"); // 跳转到 MainScene
    }
}