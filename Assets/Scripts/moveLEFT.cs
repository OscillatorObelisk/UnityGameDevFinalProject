using UnityEngine;

public class moveLEFT : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Set velocity to move left, keep current vertical velocity
        rb.linearVelocity = new Vector2(-speed, rb.linearVelocity.y);
    }
}
