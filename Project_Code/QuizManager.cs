using UnityEngine;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public GameObject dialogueImage;       // 对话Image
    public GameObject questionPage;        // 选项页面
    public GameObject correctResultImage;  // 正确答案的Image
    public GameObject wrongResultImage;    // 错误答案的Image
    public GameObject endBackgroundImage;  // 答题结束后的背景Image
    private bool isDialogueDisplayed = true;

    void Start()
    {
        // 初始状态
        dialogueImage.SetActive(true);      // 显示对话Image
        questionPage.SetActive(false);      // 隐藏问题页面
        correctResultImage.SetActive(false);
        wrongResultImage.SetActive(false);
        endBackgroundImage.SetActive(false);
    }

    void Update()
    {
        // 当对话显示时，点击鼠标左键显示问题页面
        if (isDialogueDisplayed && Input.GetMouseButtonDown(0))
        {
            ShowQuestionPage();
        }
    }

    private void ShowQuestionPage()
    {
        dialogueImage.SetActive(false); // 隐藏对话Image
        questionPage.SetActive(true);   // 显示问题页面
        isDialogueDisplayed = false;
    }

    public void OnOptionSelected(int optionIndex)
    {
        // 假设选项3是正确答案
        bool isCorrect = optionIndex == 2;

        questionPage.SetActive(false);       // 隐藏问题页面
        correctResultImage.SetActive(isCorrect);
        wrongResultImage.SetActive(!isCorrect);

        // 5秒后更改背景并跳转场景
        Invoke(nameof(ChangeBackground), 3);
    }

    private void ChangeBackground()
    {
        correctResultImage.SetActive(false);
        wrongResultImage.SetActive(false);
        endBackgroundImage.SetActive(true);

        // 5秒后跳转到 MainScene
        Invoke(nameof(LoadMainScene), 3);
    }

    private void LoadMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}