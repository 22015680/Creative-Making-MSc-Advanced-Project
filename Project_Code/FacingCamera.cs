using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacingCamera : MonoBehaviour
{
    Transform[] childs;
    void Start()
    {
        childs = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            childs[i] = transform.GetChild(i);
        }
    }

    void Update()
    {
        Quaternion cameraRotation = Camera.main.transform.rotation;
        Vector3 cameraEulerAngles = cameraRotation.eulerAngles; // 相机的欧拉角

        for (int i = 0; i < childs.Length; i++)
        {
            // 获取子物体当前的欧拉角
            Vector3 childEulerAngles = childs[i].eulerAngles;

            // 更新子物体的欧拉角，只改变Y轴（偏航角）
            childs[i].eulerAngles = new Vector3(childEulerAngles.x, cameraEulerAngles.y, childEulerAngles.z);
        }
    }
}
