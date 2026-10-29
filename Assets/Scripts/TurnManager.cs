using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class TurnManager : MonoBehaviour
{
    public const int MovesPerTurn = 3;
    private BoardGenerator boardGenerator;
    private PlayerSpawn playerSpawn;
    private GameObject currentPlayer;
    private Vector2 moveInput;
    private Vector2 targetPos;
    private int playerTurn = 0;
    private int movesLeft;
    void Start()
    {
        boardGenerator = GameObject.Find("Board").GetComponent<BoardGenerator>();
        playerSpawn = FindAnyObjectByType<PlayerSpawn>();
        movesLeft = MovesPerTurn;
    }
    void Update()
    {
        if (playerSpawn.PlayerList.Count == 0) return; // Just in case
        currentPlayer = playerSpawn.PlayerList[playerTurn];
        moveInput = InputSystem.actions["Move"].ReadValue<Vector2>();
        if (InputSystem.actions["Move"].WasPressedThisFrame())
            MoveDirection(moveInput);
        if (movesLeft <= 0) 
        {
            playerTurn= ++playerTurn% PlayerSpawn.TotalPlayers;
            movesLeft = MovesPerTurn;
        }
    }
    void MoveDirection(Vector3 dir)
    {
        if (Mathf.Abs(dir.x) < Mathf.Abs(dir.y))
            dir.x = 0;
        else
            dir.y = 0;
        targetPos = currentPlayer.transform.position + dir;
        if (Mathf.Abs(targetPos.x) <= boardGenerator.xOffset && Mathf.Abs(targetPos.y) <= boardGenerator.yOffset)
        {
            currentPlayer.transform.position = targetPos;
            --movesLeft;
        }
    }
}