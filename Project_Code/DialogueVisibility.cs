using UnityEngine;

public class DialogueVisibility : MonoBehaviour
{
    public GameObject dialogueImage; // 对话 Image 的引用

    public GameObject Buns;
    void Start()
    {   
        // 检查是否完成了第三关
        if (GameManagement.Instance != null && GameManagement.Instance.IsThirdLevelComplete)
        {
            Buns.SetActive(true);
            // 显示对话 Image
            dialogueImage.SetActive(true);

            // 5秒后调用 HideDialogue 方法隐藏对话 Image
            Invoke("HideDialogue", 5.0f);
        }
        else
        {
            // 如果第三关未完成，确保对话 Image 是隐藏的
            dialogueImage.SetActive(false);
            Buns.SetActive(false);
        }
    }

    private void HideDialogue()
    {
        // 隐藏对话 Image
        dialogueImage.SetActive(false);
    }
}