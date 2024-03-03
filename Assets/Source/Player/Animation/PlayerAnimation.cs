using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    [Inject] GameManager _gameManager;

    private void OnEnable()
    {
        GameManager.BlockPickupEvent += PlayerJump;
        GameManager.CollisionWithObstacleEvent += PlayerJump;
    }

    private void PlayerJump()
    {
        if (!_gameManager.IsGameOver)
        {
            _animator.SetTrigger("Jump");
        }
    }

    private void OnDisable()
    {
        GameManager.BlockPickupEvent -= PlayerJump;
        GameManager.CollisionWithObstacleEvent -= PlayerJump;
    }
}
