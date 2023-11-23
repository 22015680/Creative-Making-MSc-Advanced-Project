using UnityEngine;
using UnityEngine.UI;  // 引入UI命名空间

public class MainLogic : MonoBehaviour
{
    public bool isPreTaskComplete = false;
    public GameObject interactiveObject;
    public GameObject otherObject;
    public GameObject questionUI;
    public Text questionText;
    public Button[] answerButtons;  // 存储4个回答按钮的数组

    private void Start()
    {
        questionUI.SetActive(false);
        otherObject.SetActive(false);
    }

    public void CompletePreTask()
    {
        isPreTaskComplete = true;
    }

    public void OnInteractiveObjectClicked()
    {
        if (isPreTaskComplete)
        {
            questionUI.SetActive(true);
            // 在这里你可以设置你的问题文本
            questionText.text = "Your question here...";
        }
    }

    public void OnAnswerSelected(int answerIndex)
    {
        if (answerIndex == /*正确答案的索引*/1)
        {
            questionUI.SetActive(false);
            interactiveObject.SetActive(false);
            otherObject.SetActive(true);
        }
        else
        {
            isPreTaskComplete = false;
            questionUI.SetActive(false);
            // 这里可以添加任何失败后的逻辑
        }
    }
}