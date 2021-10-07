using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SplitKeyboardPlayerInputManager : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;

    private Dictionary<int, PlayerInput> existingPlayerInputs = new Dictionary<int, PlayerInput>();
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void JoinPlayer(int playerIndex, string controlScheme)
    {
        if (!existingPlayerInputs.ContainsKey(playerIndex))
        {
            var playerInput = PlayerInput.Instantiate(prefab, controlScheme: controlScheme, playerIndex: playerIndex, pairWithDevice: Keyboard.current);
            playerInput.SwitchCurrentControlScheme(controlScheme);
            existingPlayerInputs.Add(playerIndex, playerInput);
            SendMessage("OnPlayerJoined", playerInput);
            Debug.Log("player joined");
        }
    }

    public void LeavePlayer(int playerIndex)
    {
        var playerInput = existingPlayerInputs[playerIndex];
        Debug.Log(playerInput.ToString());
        Destroy(playerInput.gameObject);
        existingPlayerInputs.Remove(playerIndex);
    }
}
