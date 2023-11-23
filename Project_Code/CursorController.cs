using UnityEngine;

public class CursorController : MonoBehaviour
{
    public Texture2D customCursorTexture; // 在 Unity 编辑器中设置自定义鼠标光标纹理
    public Texture2D defaultCursorTexture; // 在 Unity 编辑器中设置默认鼠标光标纹理



    private void Update()
    {
        // 按下鼠标左键时切换到自定义光标纹理
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.SetCursor(customCursorTexture, Vector2.zero, CursorMode.Auto);
        }

        // 松开鼠标左键时恢复默认光标纹理
        if (Input.GetMouseButtonUp(0))
        {
            Cursor.SetCursor(defaultCursorTexture, Vector2.zero, CursorMode.Auto);
        }

    }
    void Awake()
    {
        // 这个函数调用会确保游戏对象在加载新场景时不被自动销毁
        DontDestroyOnLoad(gameObject);
    }
}