using UnityEngine;
using UnityEngine.SceneManagement;

public class GuardLevelTrigger : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        // �����³���
        SceneManager.LoadScene("GuardLevel");
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        SceneManager.sceneLoaded -= OnSceneLoaded; // ȡ�������¼��������ٴε���
    }
}
