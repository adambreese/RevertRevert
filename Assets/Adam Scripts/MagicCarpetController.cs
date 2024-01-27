using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCarpetController : MonoBehaviour
{
    public float speed = 5f;
    public float sinSpeed = 1.5f;
    public float amplitude = 1f;
    public float jumpForce = 8f;
    public float originalY;
    private Rigidbody rb;  // Rigidbody component

    void Start()
    {
        originalY = transform.position.y;
        rb = GetComponent<Rigidbody>();  // Get the Rigidbody component
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement vector
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f);

        // Move the carpet based on user input
        transform.Translate(movement * speed * Time.deltaTime);

        // Add a sinusoidal movement for a floating effect
        float offset = Mathf.Sin(Time.time * sinSpeed) * amplitude;
        transform.position = new Vector3(transform.position.x, originalY + offset + verticalInput*jumpForce, transform.position.z);

    }
}


