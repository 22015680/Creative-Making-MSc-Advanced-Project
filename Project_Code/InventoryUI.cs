using UnityEngine;
using System.Collections;
public class InventoryUI : MonoBehaviour
{   

    public GameObject inventoryUI; // 背包UI对象的引用

    public GameObject doughImage; // 面团Image的引用

    public GameObject fishImage;  // 鱼Image的引用

    public GameObject goldImage;  // 鱼Image的引用

    public GameObject dialogueImage;   // 第一个对话Image

    public GameObject nextImage;       // 第二个Image

    public float displayTime = 3.0f;   // 每个Image显示的时间

    void Start()
    {
        dialogueImage.SetActive(false);
        nextImage.SetActive(false);
        inventoryUI.SetActive(false); // 确保初始时背包 UI 是可见的
        fishImage.SetActive(false);

        // 检查第四关是否完成
        if (GameManagement.Instance != null && GameManagement.Instance.IsFourthLevelComplete)
         {
            // 如果完成了第四关，不显示面团Image并显示鱼Image
            doughImage.SetActive(false);
            fishImage.SetActive(true);
              StartCoroutine(DisplayImagesSequence());
        }

        if (GameManagement.Instance != null && GameManagement.Instance.IsFifthLevelComplete)
        {
            // 如果完成了第五关，不显示goldImage
            goldImage.SetActive(false);
           
        }

    }

    private IEnumerator DisplayImagesSequence()
    {
        // 显示第一个对话Image
        dialogueImage.SetActive(true);
        // 等待3秒
        yield return new WaitForSeconds(displayTime);

        // 隐藏第一个对话Image，显示第二个Image
        dialogueImage.SetActive(false);
        nextImage.SetActive(true);
        // 再等待3秒
        yield return new WaitForSeconds(displayTime);

        // 可以在这里添加第二个Image隐藏的逻辑，或者进行其他操作
        nextImage.SetActive(false);
    }

    // 更新方法中检查按键输入
    void Update()
    {
        // 如果按下了'B'键
        if (Input.GetKeyDown(KeyCode.B))
        {
            // 切换背包UI的激活状态
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    }
}