using UnityEngine;

public class DialogueVisibility : MonoBehaviour
{
    public GameObject dialogueImage; // �Ի� Image ������

    public GameObject Buns;
    void Start()
    {   
        // ����Ƿ�����˵�����
        if (GameManagement.Instance != null && GameManagement.Instance.IsThirdLevelComplete)
        {
            Buns.SetActive(true);
            // ��ʾ�Ի� Image
            dialogueImage.SetActive(true);

            // 5������ HideDialogue �������ضԻ� Image
            Invoke("HideDialogue", 5.0f);
        }
        else
        {
            // ���������δ��ɣ�ȷ���Ի� Image �����ص�
            dialogueImage.SetActive(false);
            Buns.SetActive(false);
        }
    }

    private void HideDialogue()
    {
        // ���ضԻ� Image
        dialogueImage.SetActive(false);
    }
}