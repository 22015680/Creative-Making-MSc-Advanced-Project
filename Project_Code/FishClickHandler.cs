using UnityEngine;
using UnityEngine.UI; // ����UI�����ռ�

public class FishClickHandler : MonoBehaviour
{
    public GameObject fishImage; // ���Image GameObject
    public GameObject goldImage; // ��Ԫ����Image GameObject

    void Start()
    {
        // ȷ����Ԫ����ʼʱ�����ص�
        goldImage.SetActive(false);

        // Ϊ��Image��ӵ���¼�����
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
        // �������Image
        fishImage.SetActive(false);

        // ��ʾ��Ԫ����Image
        goldImage.SetActive(true);

        GameManagement.Instance.isGoldUIActive = true;
    }
}
