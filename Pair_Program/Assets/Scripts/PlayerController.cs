using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    // public float jump;
    private float jumpForce = 10f;
    private bool isGrounded;
    private float moveSpeed = 5f;
    private Transform stick1;
    private Transform stick2;
    public Transform destinationPoint;

    void Start()
    {
        isGrounded = true;
        rb = GetComponent<Rigidbody2D>();

        stick1 = transform.GetChild(0);
        stick2 = transform.GetChild(1);
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

        float stick1Rotation = stick1.rotation.eulerAngles.z;
        float stick2Rotation = stick2.rotation.eulerAngles.z;

        if ((stick1Rotation > 90 && stick1Rotation < 270) || (stick2Rotation > 90 && stick2Rotation < 270))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }

        float distance = Vector2.Distance(transform.position, destinationPoint.position);
        
        if (distance < 13.5f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
