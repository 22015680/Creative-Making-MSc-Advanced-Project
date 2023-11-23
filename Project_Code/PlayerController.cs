using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private bool canRestart = true; // �����Ƿ�������¿�ʼ��Ϸ

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // ���ƽ�ɫ��Ծ
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    // ���������������ֹ���¿�ʼ��Ϸ
    public void DisableRestart()
    {
        canRestart = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // ����������¿�ʼ��Ϸ���������赲��ʱ���¿�ʼ��Ϸ
        if (canRestart)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}
