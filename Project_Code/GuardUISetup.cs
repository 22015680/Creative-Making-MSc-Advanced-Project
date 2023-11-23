using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardUISetup : MonoBehaviour
{
    public GameObject inventoryUI; // 背包UI对象的引用


    public GameObject guardDoughUI;

    public GameObject guardFishUI;

    public GameObject guardGoldUI;

    // Start is called before the first frame update
    void Start()
    {
        // 初始时将所有 UI 设置为不激活状态
        guardDoughUI.SetActive(false);
        guardFishUI.SetActive(false);
        guardGoldUI.SetActive(false);

        
    }
    private void SetUIStates()
    {
        if (GameManagement.Instance != null)
        {
            guardDoughUI.SetActive(GameManagement.Instance.isDoughUIActive);
            guardFishUI.SetActive(GameManagement.Instance.isFishUIActive);
            guardGoldUI.SetActive(GameManagement.Instance.isGoldUIActive);
        }
    }
    // Update is called once per frame
    void Update()
    {
        SetUIStates();
        // 如果按下了'B'键
        if (Input.GetKeyDown(KeyCode.B))
        {
            // 切换背包UI的激活状态
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    }
}
