using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class Manager : MonoBehaviourPunCallbacks
{
    [SerializeField] TMP_InputField nicknameInput;
    [SerializeField] TextMeshProUGUI waitingText;
    [SerializeField] int DEBUG_exPlayer;

    [Header("Canvases")]
    [SerializeField] GameObject playground;
    [SerializeField] GameObject menuCanvas;
    [SerializeField] GameObject findingCanvas;
    [SerializeField] GameObject waitingCanvas;
    [SerializeField] GameObject connectingCanvas;

    [Header("Objects")]
    [SerializeField] GameObject setNicknamePanel;
    [SerializeField] GameObject walletConnectButton;
    [SerializeField] GameObject findMazeButton;

    public bool gameStarted { get; private set; }
    int currentPlayerCount = 0;
    int maxPlayerCount = 0;

    NetworkManager networkManager;

    void Start()
    {
        networkManager = FindObjectOfType<NetworkManager>();

        connectingCanvas.SetActive(true);

        // Show/Hide nickname panel
        if (PlayerPrefs.HasKey("Nickname"))
        {
            setNicknamePanel.SetActive(false);
            findMazeButton.SetActive(true);
        }
        else
        {
            setNicknamePanel.SetActive(true);
            findMazeButton.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // if game not started and we are in a room check the player number to start to game
        if (!gameStarted && PhotonNetwork.CurrentRoom != null)
        {
            currentPlayerCount = PhotonNetwork.CurrentRoom.PlayerCount;
            maxPlayerCount = PhotonNetwork.CurrentRoom.MaxPlayers;

            waitingText.text = "Waiting for other players (" + 
                (currentPlayerCount + DEBUG_exPlayer) + "/" + maxPlayerCount + ")";

            if (currentPlayerCount + DEBUG_exPlayer >= maxPlayerCount)
            {
                gameStarted = true;
                waitingCanvas.SetActive(false);
            }
        }
    }

    public override void OnConnected()
    {
        connectingCanvas.SetActive(false);
        menuCanvas.SetActive(true);
    }

    public override void OnJoinedRoom()
    {
        findingCanvas.SetActive(false);
        waitingCanvas.SetActive(true);
    }

    public void Btn_SetNickname()
    {
        if (nicknameInput.text.Length == 0) return;

        PlayerPrefs.SetString("Nickname", nicknameInput.text);
        setNicknamePanel.SetActive(false);
        findMazeButton.SetActive(true);
    }

    public void Btn_UpdateNickname()
    {
        setNicknamePanel.SetActive(!setNicknamePanel.activeSelf);
    }

    public void Btn_FindMaze()
    {
        menuCanvas.SetActive(false);
        findingCanvas.SetActive(true);

        networkManager.FindMaze();
    }
}
