using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System.Collections;

public class GameTimer : MonoBehaviour
{
    public float gameTime = 60f;
    public RawImage rawImage; // RawImage 组件，用于显示视频
    public VideoPlayer videoPlayer; // VideoPlayer 组件



    void Start()
    {
        // 确保初始时 RawImage 是不激活的
        rawImage.gameObject.SetActive(false);
    }

    void Update()
    {
        gameTime -= Time.deltaTime;

        if (gameTime <= 0)
        {
            StartCoroutine(PlayVideo());
            enabled = false; // 停用此脚本以停止 Update 调用
            // 找到 PlayerController 实例并禁用重启游戏功能
            FindObjectOfType<PlayerController>().DisableRestart();
        }
    }

    IEnumerator PlayVideo()
    {  
        rawImage.gameObject.SetActive(true); // 激活 RawImage
        videoPlayer.Play(); // 播放视频

        // 等待视频播放完成
        while (videoPlayer.isPlaying)
        {
            yield return null;
        }

        // 视频播放完成后的操作
        // 例如：返回主菜单、显示得分画面等
        // SceneManager.LoadScene("MainMenu");
    }
}
