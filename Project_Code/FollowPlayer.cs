using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target; // Ŀ������������Ҫ����Ķ���
    public Vector3 offset;   // �����Ŀ���ƫ����

    void Update()
    {
        if (target != null)
        {
            // �����������λ��ΪĿ��λ�ü���ƫ����
            transform.position = target.position + offset;
        }
    }
}
