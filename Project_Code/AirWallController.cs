using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirWallController : MonoBehaviour
{
    public GameObject airWall; // 空气墙的引用

    void Update()
    {
        if (GameManagement.Instance.IsFifthLevelComplete)
        {
            Destroy(airWall);
        }
    }
}
