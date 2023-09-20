using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick1Controller : MonoBehaviour
{
    public float StickRotateSpeed = 5.0f; // Adjust the speed as needed
    public float rotationSpeed = 45f; // Adjust the rotation speed as needed
    public Rigidbody2D bodyRigidbody; // Drag and drop the "Body" Rigidbody2D here
    public float minLength = 0.0f; // The minimum length of the stick
    public float maxLength = 5.0f; // The maximum length of the stick
    public float lengthChangeSpeed = 0.1f; // The speed at which the length changes

  
    void Start()
    {
        
    }
    void Update()
    {
        // Rotate
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
        transform.Rotate(Vector3.forward, horizontalInput * StickRotateSpeed * Time.deltaTime);
        // Apply the same rotation to the cube
        bodyRigidbody.angularVelocity = horizontalInput * rotationSpeed;
        // Flexible Length
        // Get the current scale of the stick
        Vector3 currentScale = transform.localScale;

        // Check for input to increase or decrease the length
        if (Input.GetKey(KeyCode.UpArrow))
        {
            currentScale.y += lengthChangeSpeed * Time.deltaTime;
            currentScale.y = Mathf.Clamp(currentScale.y, minLength, maxLength);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            currentScale.y -= lengthChangeSpeed * Time.deltaTime;
            currentScale.y = Mathf.Clamp(currentScale.y, minLength, maxLength);
        }
        // Apply the new scale to the stick
        transform.localScale = currentScale;

    }
}
