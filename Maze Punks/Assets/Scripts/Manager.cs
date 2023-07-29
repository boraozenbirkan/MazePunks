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
    [SerializeField] GameObject winnerCanvas;
    [SerializeField] GameObject loserCanvas;

    [Header("Objects")]
    [SerializeField] GameObject setNicknamePanel;
    [SerializeField] GameObject walletConnectButton;
    [SerializeField] GameObject findMazeButton;

    public bool gameStarted { get; private set; }
    int currentPlayerCount = 0;
    int maxPlayerCount = 0;
    string sayMyName = "";

    PhotonView photonView;
    NetworkManager networkManager;

    void Start()
    {
        networkManager = FindObjectOfType<NetworkManager>();
        photonView = GetComponent<PhotonView>();

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
            else
            {
                findingCanvas.SetActive(false);
                waitingCanvas.SetActive(true);
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
        gameStarted = false;
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

    public void Btn_BackToMenu()
    {
        winnerCanvas.SetActive(false);
        loserCanvas.SetActive(false);

        // Reconnect
        StartCoroutine(CheckNetworkConnectionOnDelay());
    }

    IEnumerator CheckNetworkConnectionOnDelay()
    {
        Debug.Log("Checking network connection...");

        // First wait for disconection to avoid double CCU
        while (PhotonNetwork.IsConnected)
        {
            Debug.Log("Waiting to disconnect!");
            yield return new WaitForSeconds(1f);
        }

        // Then connect again
        while (!PhotonNetwork.IsConnectedAndReady)
        {
            if (!PhotonNetwork.IsConnected) Debug.LogWarning("Player is not connected!");
            else Debug.LogWarning("Player is connected BUT NOT READY!");

            Debug.Log("Re-Connecting to server...");
            PhotonNetwork.ConnectUsingSettings();

            yield return new WaitForSeconds(2f);
        }

        // If player is connected and ready, then open the menu
        Debug.Log("Now player is connected AND ready!");
        menuCanvas.SetActive(true);
    }


    public void GotReward(string sayMyName)
    {
        Debug.LogError("I GOT THE REWARD !!!");
        this.sayMyName = sayMyName;

        photonView.RPC("DeclaredWinner", RpcTarget.All, sayMyName);
    }

    [PunRPC]
    public void DeclaredWinner(string winnerName)
    {
        Debug.LogError("We have a winner: " + winnerName);
        
        // If we are the winner, open winner page
        if (winnerName == sayMyName)
        {
            winnerCanvas.SetActive(true);
        }
        else { loserCanvas.SetActive(true); }

        currentPlayerCount = 0;
        sayMyName = "";
        gameStarted = false;
        FindObjectOfType<MazeGenerator>().CloseMaze();

        StartCoroutine(DisconnectOnDelay());
    }

    IEnumerator DisconnectOnDelay()
    {
        PlayerController[] players = FindObjectsOfType<PlayerController>();
        foreach (PlayerController player in players) { Destroy(player); }

        yield return new WaitForSeconds(2f);
        PhotonNetwork.Disconnect();
    }
}
