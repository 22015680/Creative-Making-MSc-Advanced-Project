using UnityEngine;
using UnityEngine.SceneManagement;

public class Fishing_Trigger : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        // �����³���
        SceneManager.LoadScene("Fishing");
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        SceneManager.sceneLoaded -= OnSceneLoaded; // ȡ�������¼��������ٴε���
    }
}
