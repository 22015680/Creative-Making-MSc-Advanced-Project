using UnityEngine;

public class MouseController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Unlock the mouse cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}