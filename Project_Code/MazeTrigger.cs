using UnityEngine;
using UnityEngine.SceneManagement;

public class MazeTrigger : MonoBehaviour
{
   

    private void OnMouseDown()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        // �����³���
        SceneManager.LoadScene("maze");
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        
        SceneManager.sceneLoaded -= OnSceneLoaded; // ȡ�������¼��������ٴε���
    }


}