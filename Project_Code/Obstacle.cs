using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float moveSpeed = 5f; // ��ʼ�ƶ��ٶ�
    public float speedIncreaseRate = 0.1f; // �ƶ��ٶȵ�����
    private float leftEdgeOfScreen;

    void Start()
    {
        // ������Ļ����x����
        leftEdgeOfScreen = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
    }

    void Update()
    {
        // �����ƶ�
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

        // �������ƶ��ٶ�
        moveSpeed += speedIncreaseRate * Time.deltaTime;

        // ���赲���Ƴ���Ļ��ʱ����
        if (transform.position.x < leftEdgeOfScreen - 1) // -1Ϊ��������
        {
            Destroy(gameObject);
        }
    }
}
