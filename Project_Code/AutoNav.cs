using UnityEngine;
using UnityEngine.AI;

public class AutoNav : MonoBehaviour
{


    public Transform target; // Ŀ��λ��
    private NavMeshAgent agent;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        if (target != null)
        {
            agent.destination = target.position; // ����Ϸ��ʼǰ����Ŀ��
        }
    }
}