using UnityEngine;

// GameController requires the GameObject to have a BallSpawner component
[RequireComponent(typeof(BallSpawner))]
public class GameController: MonoBehaviour, IGameController
{
    public bool IsGameInProgress { get; private set; }
    private BallController ballController;

	void Start ()
    {
        InitBallController();
	}

    private void InitBallController()
    {
        BallSpawner ballSpawnerComponent = GetComponent<BallSpawner>();
        ballController = new BallController(ballSpawnerComponent);
    }

    public void TryStartGame()
    {
        if (IsGameInProgress)
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
