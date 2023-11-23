using UnityEngine;
using TMPro; // ����TextMeshPro�����ռ�

public class CountdownTimer : MonoBehaviour
{
    public TextMeshProUGUI countdownText; // TMP���
    private float countdown = 60.0f; // ����ʱ��ʱ��

    void Update()
    {
        if (countdown > 0)
        {
            countdown -= Time.deltaTime;
            countdownText.text = "Time: " + Mathf.CeilToInt(countdown).ToString();
        }
        else
        {
            countdownText.text = "Time's up!";
            // �������������ʱ���������߼�
        }
    }
}
