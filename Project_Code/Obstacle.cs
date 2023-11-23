using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float moveSpeed = 5f; // 初始移动速度
    public float speedIncreaseRate = 0.1f; // 移动速度递增率
    private float leftEdgeOfScreen;

    void Start()
    {
        // 计算屏幕左侧的x坐标
        leftEdgeOfScreen = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
    }

    void Update()
    {
        // 向左移动
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

        // 逐渐增加移动速度
        moveSpeed += speedIncreaseRate * Time.deltaTime;

        // 当阻挡物移出屏幕外时销毁
        if (transform.position.x < leftEdgeOfScreen - 1) // -1为缓冲区域
        {
            Destroy(gameObject);
        }
    }
}
