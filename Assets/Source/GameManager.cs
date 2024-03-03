using UnityEngine;

public class GameManager : MonoBehaviour
{
    public delegate void GameEventHandler();
    public static event GameEventHandler GameStartEvent;
    public static event GameEventHandler BlockPickupEvent;
    public static event GameEventHandler CollisionWithObstacleEvent;
    public static event GameEventHandler GameOverEvent;

    private bool _isGameStarted = false;
    private bool _isGameOver = false;

    public bool IsGameStarted
    {
        get { return _isGameStarted; }
    }

    public bool IsGameOver
    {
        get { return _isGameOver; }
    }

    public void StartGame()
    {
        _isGameStarted = true;
        OnGameStart();
    }

    public void PickUpBlock()
    {
        OnBlockPickup();
    }

    public void HandleCollisionWithObstacle()
    {
        OnCollisionWithObstacle();
    }

    public void GameOver()
    {
        _isGameOver = true;
        _isGameStarted = false;
        OnGameOver();
    }

    private void OnGameStart()
    {
        GameStartEvent?.Invoke();
    }

    private void OnBlockPickup()
    {
        BlockPickupEvent?.Invoke();
    }

    private void OnCollisionWithObstacle()
    {
        CollisionWithObstacleEvent?.Invoke();
    }

    private void OnGameOver()
    {
        GameOverEvent?.Invoke();
    }
}
