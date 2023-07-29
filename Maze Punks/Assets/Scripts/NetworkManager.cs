using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    [SerializeField] PlayerController playerPrefab;

    Manager gameManager;

    bool waitingToTryAgain;

    void Start()
    {
        gameManager = FindObjectOfType<Manager>();

        PhotonNetwork.ConnectUsingSettings();
    }

    public void FindMaze()
    {
        if (waitingToTryAgain) return;

        Debug.Log("Finding a maze...");
        Debug.Log("Continue to check master connection");
        if (PhotonNetwork.IsConnected)
        {
            Debug.Log("Connected to master! Clearing the game and joining random room!");
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            Debug.Log("No master connection! Trying to connect again!");
            // If we are not connected at the moment, try it once more
            StartCoroutine(TryAgainToFindMatch());
            return;
        }
    }

    public void CancelMatchMaking()
    {
        try { PhotonNetwork.Disconnect(); } catch { Debug.LogError("Cancel MM, Can't disconnect!"); }
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to server");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.LogError("Join Random Room Failed! No random room available, so we create one.\nCalling: PhotonNetwork.CreateRoom");

        // Set the max player
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = (byte)3;

        // Set random room name
        string roomName = "Room_" + Random.Range(0, 100000);

        // Create the room
        PhotonNetwork.CreateRoom(roomName, roomOptions);
    }
    
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.LogError("RETURN CODE: " + returnCode + " MESSAGE: " + message);

        Debug.LogWarning("Trying to join a room AGAIN!");

        if (PhotonNetwork.IsConnected)
            PhotonNetwork.JoinRandomRoom();
        else
            StartCoroutine(TryAgainToFindMatch());
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("We're in the lobby.");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("We're connected and in a room!");
        SpawnPlayer();

        gameManager.JoinedRoom();
    }

    private void SpawnPlayer()
    {
        GameObject _player = PhotonNetwork.Instantiate(playerPrefab.name, Vector3.zero, Quaternion.identity);
        _player.GetComponent<PhotonView>().Controller.NickName = PlayerPrefs.GetString("Nickname");
    }

    private IEnumerator TryAgainToFindMatch()
    {
        Debug.LogWarning("Trying to reconnect and find match again!");

        waitingToTryAgain = true;

        Debug.Log("Connecting to server...");
        PhotonNetwork.ConnectUsingSettings();

        yield return new WaitForSeconds(3f);

        waitingToTryAgain = false;
        FindMaze();
    }
}
