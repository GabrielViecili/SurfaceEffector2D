using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Configuracoes de Pulo")]
    public float jumpForce = 12f;
    public int maxJumps = 2;

    private Rigidbody2D rb;
    private int jumpsLeft;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpsLeft = maxJumps;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (jumpsLeft > 0 && GameManager.instance.isRunning)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                jumpsLeft--;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
            jumpsLeft = maxJumps;

        if (col.gameObject.CompareTag("Obstacle"))
            GameManager.instance.GameOver();
    }
}