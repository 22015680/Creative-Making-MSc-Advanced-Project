using UnityEngine;
using UnityEngine.SceneManagement;

public class MazeTrigger : MonoBehaviour
{
   

    private void OnMouseDown()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        // 加载新场景
        SceneManager.LoadScene("maze");
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        
        SceneManager.sceneLoaded -= OnSceneLoaded; // 取消订阅事件，以免再次调用
    }


}