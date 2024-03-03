using UnityEngine;
using Zenject;

public class WarpEffectMovement : MonoBehaviour
{
    [SerializeField, Min(0)] private float lerpValue;
    [SerializeField] private Vector3 offset;
    [SerializeField] private Transform heroTransform;

    private Vector3 newPosition;

    [Inject] private GameManager _gameManager;

    void LateUpdate()
    {
        if(_gameManager.IsGameStarted && !_gameManager.IsGameOver)
        {
            SetCameraSmoothFollow();
        }
    }

    private void SetCameraSmoothFollow()
    {
        newPosition = Vector3.Lerp(transform.position, new Vector3(0f, 0f, heroTransform.position.z) + offset, lerpValue * Time.deltaTime);
        transform.position = newPosition;
    }
}
