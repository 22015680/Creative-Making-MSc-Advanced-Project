using UnityEngine;
using TMPro; // 引用TextMeshPro命名空间

public class CountdownTimer : MonoBehaviour
{
    public TextMeshProUGUI countdownText; // TMP组件
    private float countdown = 60.0f; // 倒计时总时长

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
            // 可以在这里添加时间结束后的逻辑
        }
    }
}
