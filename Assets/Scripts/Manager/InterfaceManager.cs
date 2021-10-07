using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InterfaceManager : MonoBehaviour
{
    [SerializeField]
    private Button joinPlayerOne;

    [SerializeField]
    private Button joinPlayerTwo;

    [SerializeField]
    private SplitKeyboardPlayerInputManager playerInputManager;

    private bool player1 = false;
    private bool player2 = false;
    // Start is called before the first frame update
    void Start()
    {
        joinPlayerOne.onClick.AddListener(() => JoinPlayerOne());
        joinPlayerTwo.onClick.AddListener(() => JoinPlayerTwo());
    }

    private void JoinPlayerOne()
    {
        if (!player1)
        {
            playerInputManager.JoinPlayer(0, "Keyboard&Mouse");
            player1 = true;
            var text = joinPlayerOne.GetComponentInChildren<Text>();
            text.text = "Leave Player One";
        }
        else
        {
            playerInputManager.LeavePlayer(0);
            player1 = false;
            var text = joinPlayerOne.GetComponentInChildren<Text>();
            text.text = "Join Player One";
        }
    }

    private void JoinPlayerTwo()
    {
        if (!player2)
        {
            playerInputManager.JoinPlayer(1, "PlayerTwo");
            player2 = true;
            var text = joinPlayerTwo.GetComponentInChildren<Text>();
            text.text = "Leave Player Two";
        } else
        {
            playerInputManager.LeavePlayer(1);
            player2 = false;
            var text = joinPlayerTwo.GetComponentInChildren<Text>();
            text.text = "Join Player Two";
        }
    }
}
