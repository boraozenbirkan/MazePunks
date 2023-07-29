using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;
using Photon.Pun;


public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float damping = 1f;
    [SerializeField] TextMeshProUGUI nicknameText;

    Rigidbody2D rb;
    CinemachineVirtualCamera cam;
    PhotonView photonView;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = FindAnyObjectByType<CinemachineVirtualCamera>();
        photonView = GetComponent<PhotonView>();
    }

    private void Start()
    {
        if (photonView.IsMine)
        {
            nicknameText.text = PlayerPrefs.GetString("Nickname");
            cam.Follow = transform;
        }
        else
        {
            nicknameText.text = GetComponent<PhotonView>().Controller.NickName;
        }
    }

    private void FixedUpdate()
    {
        if (!photonView.IsMine) return; // Don't run if it's not mine.

        // Get input for horizontal and vertical movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector2 movement = new Vector2(horizontalInput, verticalInput);

        // Move the object
        rb.velocity = movement * moveSpeed;
    }
}
