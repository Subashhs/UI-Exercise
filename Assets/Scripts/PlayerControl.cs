using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // For UI components

public class PlayerControl : MonoBehaviour
{
    public float jump = 10f;

    private float moveInput;

    public Rigidbody2D rb;

    // Reference to the speed slider
    public Slider speedSlider;
    private float speed;

    // For ground detection
    public Transform groundCheck;
    public LayerMask groundLayer;
    private bool isGrounded;

    void Start()
    {
        // Set the initial speed based on the slider value
        speed = speedSlider.value;

        // Add a listener to the slider to handle value changes
        speedSlider.onValueChanged.AddListener(UpdateSpeed);

        // Optionally, disable the slider's interaction so it can only be controlled via mouse
        speedSlider.interactable = true;
    }

    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");

        // Move the player
        rb.velocity = new Vector2(speed * moveInput, rb.velocity.y);

        // Check if the player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

        // Jump if grounded
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector2(0f, jump), ForceMode2D.Impulse);
        }
    }

    // Update the speed based on the slider value
    void UpdateSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
}
