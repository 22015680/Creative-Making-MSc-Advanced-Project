using UnityEngine;
using System.Collections;
public class InventoryUI : MonoBehaviour
{   

    public GameObject inventoryUI; // ����UI���������

    public GameObject doughImage; // ����Image������

    public GameObject fishImage;  // ��Image������

    public GameObject goldImage;  // ��Image������

    public GameObject dialogueImage;   // ��һ���Ի�Image

    public GameObject nextImage;       // �ڶ���Image

    public float displayTime = 3.0f;   // ÿ��Image��ʾ��ʱ��

    void Start()
    {
        dialogueImage.SetActive(false);
        nextImage.SetActive(false);
        inventoryUI.SetActive(false); // ȷ����ʼʱ���� UI �ǿɼ���
        fishImage.SetActive(false);

        // �����Ĺ��Ƿ����
        if (GameManagement.Instance != null && GameManagement.Instance.IsFourthLevelComplete)
         {
            // �������˵��Ĺأ�����ʾ����Image����ʾ��Image
            doughImage.SetActive(false);
            fishImage.SetActive(true);
              StartCoroutine(DisplayImagesSequence());
        }

        if (GameManagement.Instance != null && GameManagement.Instance.IsFifthLevelComplete)
        {
            // �������˵���أ�����ʾgoldImage
            goldImage.SetActive(false);
           
        }

    }

    private IEnumerator DisplayImagesSequence()
    {
        // ��ʾ��һ���Ի�Image
        dialogueImage.SetActive(true);
        // �ȴ�3��
        yield return new WaitForSeconds(displayTime);

        // ���ص�һ���Ի�Image����ʾ�ڶ���Image
        dialogueImage.SetActive(false);
        nextImage.SetActive(true);
        // �ٵȴ�3��
        yield return new WaitForSeconds(displayTime);

        // ������������ӵڶ���Image���ص��߼������߽�����������
        nextImage.SetActive(false);
    }

    // ���·����м�鰴������
    void Update()
    {
        // ���������'B'��
        if (Input.GetKeyDown(KeyCode.B))
        {
            // �л�����UI�ļ���״̬
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    }
}