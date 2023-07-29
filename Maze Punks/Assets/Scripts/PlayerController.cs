using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float damping = 1f;

    Rigidbody2D rb;
    CinemachineVirtualCamera cam;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = FindAnyObjectByType<CinemachineVirtualCamera>();
        cam.Follow = transform;
    }

    private void FixedUpdate()
    {
        // Get input for horizontal and vertical movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector2 movement = new Vector2(horizontalInput, verticalInput);

        // Move the object
        rb.velocity = movement * moveSpeed;
    }
}
