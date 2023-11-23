using UnityEngine;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public GameObject dialogueImage;       // �Ի�Image
    public GameObject questionPage;        // ѡ��ҳ��
    public GameObject correctResultImage;  // ��ȷ�𰸵�Image
    public GameObject wrongResultImage;    // ����𰸵�Image
    public GameObject endBackgroundImage;  // ���������ı���Image
    private bool isDialogueDisplayed = true;

    void Start()
    {
        // ��ʼ״̬
        dialogueImage.SetActive(true);      // ��ʾ�Ի�Image
        questionPage.SetActive(false);      // ��������ҳ��
        correctResultImage.SetActive(false);
        wrongResultImage.SetActive(false);
        endBackgroundImage.SetActive(false);
    }

    void Update()
    {
        // ���Ի���ʾʱ�������������ʾ����ҳ��
        if (isDialogueDisplayed && Input.GetMouseButtonDown(0))
        {
            ShowQuestionPage();
        }
    }

    private void ShowQuestionPage()
    {
        dialogueImage.SetActive(false); // ���ضԻ�Image
        questionPage.SetActive(true);   // ��ʾ����ҳ��
        isDialogueDisplayed = false;
    }

    public void OnOptionSelected(int optionIndex)
    {
        // ����ѡ��3����ȷ��
        bool isCorrect = optionIndex == 2;

        questionPage.SetActive(false);       // ��������ҳ��
        correctResultImage.SetActive(isCorrect);
        wrongResultImage.SetActive(!isCorrect);

        // 5�����ı�������ת����
        Invoke(nameof(ChangeBackground), 3);
    }

    private void ChangeBackground()
    {
        correctResultImage.SetActive(false);
        wrongResultImage.SetActive(false);
        endBackgroundImage.SetActive(true);

        // 5�����ת�� MainScene
        Invoke(nameof(LoadMainScene), 3);
    }

    private void LoadMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}