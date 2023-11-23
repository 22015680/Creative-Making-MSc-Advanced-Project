using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rice_Visibility : MonoBehaviour
{
    // 假设这是你想控制显示的GameObject
    public GameObject objectToShow;

    private void Start()
    {
        // 如果玩家完成了第二关，显示这个对象
        if (GameManagement.Instance != null && GameManagement.Instance.IsThirdLevelComplete)
        {
            objectToShow.SetActive(true);
        }
        else
        {
            objectToShow.SetActive(false);
        }
    }
}
