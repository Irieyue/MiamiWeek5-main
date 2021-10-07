using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public enum PlayerNumber { PlayerOne, PlayerTwo }
    [SerializeField]
    private Rigidbody rigidbody;
    [SerializeField]
    private float speed;
    [SerializeField]
    private PlayerInput playerInput;
    [SerializeField]
    private MeshRenderer meshRenderer;

    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        rigidbody.MovePosition(transform.position + (direction * speed * Time.deltaTime));
    }

    public void OnMove(InputValue value)
    {
        Debug.Log("Move: " + value.Get<Vector2>());
        var dir = value.Get<Vector2>();
        direction.x = dir.x;
        direction.z = dir.y;
    }

    public void SetPlayer(PlayerNumber playerNumber)
    {
        if (playerNumber == PlayerNumber.PlayerOne)
        {
            meshRenderer.material.color = Color.blue;
        }

        if (playerNumber == PlayerNumber.PlayerTwo)
        {
            meshRenderer.material.color = Color.red;
        }
    }
}
