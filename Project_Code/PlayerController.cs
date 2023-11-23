using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private bool canRestart = true; // 控制是否可以重新开始游戏

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 控制角色跳跃
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    // 调用这个方法来禁止重新开始游戏
    public void DisableRestart()
    {
        canRestart = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // 如果可以重新开始游戏，且碰到阻挡物时重新开始游戏
        if (canRestart)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}
