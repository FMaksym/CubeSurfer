using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Player _player;

    private float _currentSpeed;
    private float _acceleration = 5f;

    [Inject] private GameManager _gameManager;

    private void FixedUpdate()
    {
        if (_gameManager.IsGameStarted && !_gameManager.IsGameOver)
        {
            MobileInput();
            ForwardMovement();
            HorizontalMovement();
        }
    }

    private void MobileInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                float horizontalValue = touch.deltaPosition.x / Screen.width;
                _player.HorizontalValue = horizontalValue;
            } else {
                _player.HorizontalValue = 0f;
            }
        } else {
            _player.HorizontalValue = 0f;
        }
    }

    private void ForwardMovement()
    {
        transform.Translate(transform.forward * _player.ForwardMovementSpeed * Time.fixedDeltaTime);

        //_currentSpeed = Mathf.MoveTowards(_currentSpeed, _player.ForwardMovementSpeed, _acceleration * Time.fixedDeltaTime);
        //transform.Translate(transform.forward * _currentSpeed * Time.fixedDeltaTime);
    }

    private void HorizontalMovement()
    {
        float newPositionX = transform.position.x + _player.HorizontalValue * _player.HorizontalMovementSpeed * Time.fixedDeltaTime;
        newPositionX = Mathf.Clamp(newPositionX, -_player.LimitHorizontalPosition, _player.LimitHorizontalPosition);

        transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);
    }
}