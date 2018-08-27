public interface IGameController
{
    void TryStartGame();
    void EndGame();
    bool IsGameInProgress { get; }
}