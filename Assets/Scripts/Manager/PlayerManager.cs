using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public void OnPlayerJoined(PlayerInput playerInput)
    {
        var playerController = playerInput.GetComponent<PlayerController>();
        var playerNumber = (PlayerController.PlayerNumber)playerInput.playerIndex;
        playerController.SetPlayer(playerNumber);
    }

    public void OnPlayerLeft(PlayerInput playerInput)
    {
       
    }
}
