using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject videoUI; // 视频播放的UI元素
    public GameObject dialogueBackground; // 对话背景
    public GameObject[] dialogueImages;
    private int currentDialogueIndex = 0;
    private bool canShowDialogue = false; // 新增变量，控制对话UI是否可以显示

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
        videoUI.SetActive(false); // 隐藏视频播放的UI
     
        // 显示对话图片和背景
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
            // 所有对话图片显示完毕，等待下一次点击后跳转到 MainScene
            SceneManager.LoadScene("MainScene");
        }
    }

    void SetDialogueImagesActive(bool isActive)
    {
        foreach (var img in dialogueImages)
        {
            img.SetActive(false);
        }

        // 如果需要激活对话UI，则仅显示第一张图片
        if (isActive && dialogueImages.Length > 0)
        {
            dialogueImages[0].SetActive(true);
            currentDialogueIndex = 1; // 开始时，准备显示第二张图片
        }
    }
}