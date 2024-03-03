using UnityEngine;
using Zenject;

public class GameStartInputHandler : MonoBehaviour
{
    [Inject] private GameManager _gameManager;

    void Update()
    {
        if (!_gameManager.IsGameStarted && !_gameManager.IsGameOver)
        {
            if (Input.touchCount > 0)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    _gameManager.StartGame();
                }
            }
        }
    }
}
