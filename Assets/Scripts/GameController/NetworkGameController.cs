using System;
using UnityEngine;
using UnityEngine.Networking;

// GameController requires the GameObject to have a BallSpawner component
[RequireComponent(typeof(BallSpawner))]
public class NetworkGameController : NetworkBehaviour, IGameController
{
    public bool IsGameInProgress { get; private set; }

    private BallController ballController;
    private bool isInitialized;

    void Start()
    {
        Init();
    }

    private void Init()
    {
        InitBallController();
        isInitialized = true;
    }

    private void InitBallController()
    {
        BallSpawner ballSpawnerComponent = GetComponent<BallSpawner>();
        ballController = new BallController(ballSpawnerComponent);
        ballController.OnBallSpawned += OnBallSpawned;
    }

    private void OnBallSpawned(Ball ball)
    {
        if (NetworkServer.active)
            NetworkServer.Spawn(ball.gameObject);
    }

    [Command]
    public void CmdRequestGameStart()
    {
        TryStartGame();
    }

    public void TryStartGame()
    {
        if (IsGameInProgress || !isInitialized)
            return;
        ballController.OnGameStart();
        IsGameInProgress = true;
    }

    public void EndGame()
    {
        ballController.OnGameEnd();
        IsGameInProgress = false;
    }
}