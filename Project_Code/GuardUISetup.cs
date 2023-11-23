using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardUISetup : MonoBehaviour
{
    public GameObject inventoryUI; // ����UI���������


    public GameObject guardDoughUI;

    public GameObject guardFishUI;

    public GameObject guardGoldUI;

    // Start is called before the first frame update
    void Start()
    {
        // ��ʼʱ������ UI ����Ϊ������״̬
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
        // ���������'B'��
        if (Input.GetKeyDown(KeyCode.B))
        {
            // �л�����UI�ļ���״̬
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    }
}
