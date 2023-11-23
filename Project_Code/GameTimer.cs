using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System.Collections;

public class GameTimer : MonoBehaviour
{
    public float gameTime = 60f;
    public RawImage rawImage; // RawImage �����������ʾ��Ƶ
    public VideoPlayer videoPlayer; // VideoPlayer ���



    void Start()
    {
        // ȷ����ʼʱ RawImage �ǲ������
        rawImage.gameObject.SetActive(false);
    }

    void Update()
    {
        gameTime -= Time.deltaTime;

        if (gameTime <= 0)
        {
            StartCoroutine(PlayVideo());
            enabled = false; // ͣ�ô˽ű���ֹͣ Update ����
            // �ҵ� PlayerController ʵ��������������Ϸ����
            FindObjectOfType<PlayerController>().DisableRestart();
        }
    }

    IEnumerator PlayVideo()
    {  
        rawImage.gameObject.SetActive(true); // ���� RawImage
        videoPlayer.Play(); // ������Ƶ

        // �ȴ���Ƶ�������
        while (videoPlayer.isPlaying)
        {
            yield return null;
        }

        // ��Ƶ������ɺ�Ĳ���
        // ���磺�������˵�����ʾ�÷ֻ����
        // SceneManager.LoadScene("MainMenu");
    }
}
