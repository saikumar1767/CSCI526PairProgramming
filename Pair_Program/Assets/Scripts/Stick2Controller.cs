using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick2Controller : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f; // Adjust the speed as needed
    private Rigidbody2D cubeTransform;

    void Start()
    {
        cubeTransform = transform.parent.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float horizontalInput = 0f;

        if (Input.GetKey(KeyCode.A))
        {
            horizontalInput = -1f; // Left (A) key is pressed
        }
        else if (Input.GetKey(KeyCode.D))
        {
            horizontalInput = 1f; // Right (D) key is pressed
        }

        // Apply the rotation to the stick
        transform.Rotate(Vector3.forward, horizontalInput * _speed * Time.deltaTime);
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        // Calculate movement direction based on the rotated stick
        Vector2 moveDirection = transform.up * Input.GetAxisRaw("Vertical") + transform.right * Input.GetAxisRaw("Horizontal");

        // Apply movement to the cube
        cubeTransform.AddForce(moveDirection * Time.deltaTime, ForceMode2D.Force);
    }
}
