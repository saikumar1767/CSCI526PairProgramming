using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick2Controller : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f; // Adjust the speed as needed
    public Rigidbody2D bodyRigidbody;
    public float rotationSpeed = 45f; // Adjust the rotation speed as needed

    void Start()
    {
       
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

        bodyRigidbody.angularVelocity = horizontalInput * rotationSpeed;
    }
}
