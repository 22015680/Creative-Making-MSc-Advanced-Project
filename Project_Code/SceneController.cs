using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject videoUI; // ��Ƶ���ŵ�UIԪ��
    public GameObject dialogueBackground; // �Ի�����
    public GameObject[] dialogueImages;
    private int currentDialogueIndex = 0;
    private bool canShowDialogue = false; // �������������ƶԻ�UI�Ƿ������ʾ

    void Start()
    {
        videoPlayer.loopPointReached += OnVideoEnded;
        SetDialogueImagesActive(false);
        dialogueBackground.SetActive(false);
    }

    void Update()
    {
        if (canShowDialogue && Input.GetMouseButtonDown(0))
        {
            NextDialogue();
        }
    }

    void OnVideoEnded(VideoPlayer vp)
    {
        videoUI.SetActive(false); // ������Ƶ���ŵ�UI
     
        // ��ʾ�Ի�ͼƬ�ͱ���
        dialogueBackground.SetActive(true);
        canShowDialogue = true;
        SetDialogueImagesActive(true);
    }


    void NextDialogue()
    {
        if (currentDialogueIndex < dialogueImages.Length)
        {
            if (currentDialogueIndex > 0)
            {
                dialogueImages[currentDialogueIndex - 1].SetActive(false);
            }

            if (currentDialogueIndex < dialogueImages.Length)
            {
                dialogueImages[currentDialogueIndex].SetActive(true);
                currentDialogueIndex++;
            }
        }
        else
        {
            // ���жԻ�ͼƬ��ʾ��ϣ��ȴ���һ�ε������ת�� MainScene
            SceneManager.LoadScene("MainScene");
        }
    }

    void SetDialogueImagesActive(bool isActive)
    {
        foreach (var img in dialogueImages)
        {
            img.SetActive(false);
        }

        // �����Ҫ����Ի�UI�������ʾ��һ��ͼƬ
        if (isActive && dialogueImages.Length > 0)
        {
            dialogueImages[0].SetActive(true);
            currentDialogueIndex = 1; // ��ʼʱ��׼����ʾ�ڶ���ͼƬ
        }
    }
}