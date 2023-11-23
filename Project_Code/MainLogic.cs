using UnityEngine;
using UnityEngine.UI;  // ����UI�����ռ�

public class MainLogic : MonoBehaviour
{
    public bool isPreTaskComplete = false;
    public GameObject interactiveObject;
    public GameObject otherObject;
    public GameObject questionUI;
    public Text questionText;
    public Button[] answerButtons;  // �洢4���ش�ť������

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
            // �����������������������ı�
            questionText.text = "Your question here...";
        }
    }

    public void OnAnswerSelected(int answerIndex)
    {
        if (answerIndex == /*��ȷ�𰸵�����*/1)
        {
            questionUI.SetActive(false);
            interactiveObject.SetActive(false);
            otherObject.SetActive(true);
        }
        else
        {
            isPreTaskComplete = false;
            questionUI.SetActive(false);
            // �����������κ�ʧ�ܺ���߼�
        }
    }
}