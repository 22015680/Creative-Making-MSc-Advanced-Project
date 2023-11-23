using UnityEngine;
using UnityEngine.AI;

public class AutoNav : MonoBehaviour
{


    public Transform target; // 目标位置
    private NavMeshAgent agent;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        if (target != null)
        {
            agent.destination = target.position; // 在游戏开始前设置目标
        }
    }
}