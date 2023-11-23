using UnityEngine;

public class CursorController : MonoBehaviour
{
    public Texture2D customCursorTexture; // �� Unity �༭���������Զ������������
    public Texture2D defaultCursorTexture; // �� Unity �༭��������Ĭ�����������



    private void Update()
    {
        // ����������ʱ�л����Զ���������
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.SetCursor(customCursorTexture, Vector2.zero, CursorMode.Auto);
        }

        // �ɿ�������ʱ�ָ�Ĭ�Ϲ������
        if (Input.GetMouseButtonUp(0))
        {
            Cursor.SetCursor(defaultCursorTexture, Vector2.zero, CursorMode.Auto);
        }

    }
    void Awake()
    {
        // ����������û�ȷ����Ϸ�����ڼ����³���ʱ�����Զ�����
        DontDestroyOnLoad(gameObject);
    }
}