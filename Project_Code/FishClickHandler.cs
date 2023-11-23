using UnityEngine;
using UnityEngine.UI; // 引入UI命名空间

public class FishClickHandler : MonoBehaviour
{
    public GameObject fishImage; // 鱼的Image GameObject
    public GameObject goldImage; // 金元宝的Image GameObject

    void Start()
    {
        // 确保金元宝初始时是隐藏的
        goldImage.SetActive(false);

        // 为鱼Image添加点击事件监听
        Button fishButton = fishImage.GetComponentInChildren<Button>();
        if (fishButton != null)
        {
            fishButton.onClick.AddListener(OnFishClicked);
        }
        else
        {
            Debug.LogError("Button component not found on fishImage or its children.");
        }
    }

   public void OnFishClicked()
    {
        // 隐藏鱼的Image
        fishImage.SetActive(false);

        // 显示金元宝的Image
        goldImage.SetActive(true);

        GameManagement.Instance.isGoldUIActive = true;
    }
}
