using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick1Controller : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f; // Adjust the speed as needed
    public float rotationSpeed = 45f; // Adjust the rotation speed as needed
    public Rigidbody2D bodyRigidbody; // Drag and drop the "Body" Rigidbody2D here


    void Start()
    {
       
    }
    void Update()
    {
        float horizontalInput = 0f;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            horizontalInput = -1f; // Left arrow key is pressed
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            horizontalInput = 1f; // Right arrow key is pressed
        }

        // Apply the rotation to the stick
        transform.Rotate(Vector3.forward, horizontalInput * _speed * Time.deltaTime);
        // Apply the same rotation to the cube
        bodyRigidbody.angularVelocity = horizontalInput * rotationSpeed;
    }
}
