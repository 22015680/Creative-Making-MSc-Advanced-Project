using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirWallController : MonoBehaviour
{
    public GameObject airWall; // ����ǽ������

    void Update()
    {
        if (GameManagement.Instance.IsFifthLevelComplete)
        {
            Destroy(airWall);
        }
    }
}
