using UnityEngine;
using UnityEngine.SceneManagement;

public class Level3Complete : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManagement.Instance.IsThirdLevelComplete = true;
            SceneManager.LoadScene("MainScene");
        }
    }


}
