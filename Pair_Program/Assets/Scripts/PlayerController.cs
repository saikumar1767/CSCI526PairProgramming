using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    // public float jump;
    private float jumpForce = 5f;
    private bool isGrounded;
    private float moveSpeed = 3f;
    void Start()
    {
        isGrounded = true;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }

        if (Input.GetKey("m"))
        {
            MoveInAir(Vector2.right);
        }

        if (Input.GetKey("n"))
        {
            MoveInAir(Vector2.left);
        }
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        isGrounded = false;
    }

    void MoveInAir(Vector2 direction)
    {
        Vector2 velocity = rb.velocity;
        velocity.x += direction.x * moveSpeed * Time.deltaTime;
        rb.velocity = velocity;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
