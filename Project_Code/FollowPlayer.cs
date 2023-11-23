using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target; // 目标对象，摄像机需要跟随的对象
    public Vector3 offset;   // 相对于目标的偏移量

    void Update()
    {
        if (target != null)
        {
            // 设置摄像机的位置为目标位置加上偏移量
            transform.position = target.position + offset;
        }
    }
}
