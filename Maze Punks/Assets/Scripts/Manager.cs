using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Manager : MonoBehaviour
{
    [SerializeField] TMP_InputField nicknameInput;

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

    void Start()
    {
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
        
    }

    public void JoinedRoom() 
    {
        menuCanvas.SetActive(false);
        playground.SetActive(true);
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
}
