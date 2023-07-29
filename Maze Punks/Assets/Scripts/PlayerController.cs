using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;
using Photon.Pun;


public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] TextMeshProUGUI nicknameText;

    Rigidbody2D rb;
    CinemachineVirtualCamera cam;
    PhotonView photonView;
    Manager manager;

    bool hit;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        photonView = GetComponent<PhotonView>();

        cam = FindAnyObjectByType<CinemachineVirtualCamera>();
        manager = FindAnyObjectByType<Manager>();
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
        // Don't run if it's not mine OR game is not started yet!
        if (!photonView.IsMine || !manager.gameStarted) return; 

        // Get input for horizontal and vertical movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector2 movement = new Vector2(horizontalInput, verticalInput);

        // Move the object
        rb.velocity = movement * moveSpeed;

        if (Input.GetMouseButtonDown(0))
        {
            // Get the mouse position in world coordinates
            Vector3 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.z = 0f; // Make sure the Z-coordinate is correct (0 in 2D)

            // Move the object instantly to the mouse click position
            transform.position = targetPosition;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!photonView.IsMine || hit) return;

        

        Debug.Log("I hit: " + collision.collider.gameObject.name);
        if (collision.collider.gameObject.name == "Reward")
        {
            manager.GotReward(PlayerPrefs.GetString("Nickname"));
            hit = true; // don't execute again
        }
    }
}
