using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject _playerModel;

    [Header("Player Movement Speed")]
    [SerializeField, Min(0)] private float _forwardMovementSpeed = 1f;
    [SerializeField, Min(0)] private float _horizontalMovementSpeed = 250f;
    [Space]
    [Header("Player Horizontal Position Limit")]
    [SerializeField, Min(0)] private float _limitHorizontalPosition;
    
    private float _horizontalValue;

    public float ForwardMovementSpeed { get { return _forwardMovementSpeed; } set { } }
    public float HorizontalMovementSpeed { get { return _horizontalMovementSpeed; } set { } }
    public float LimitHorizontalPosition { get { return _limitHorizontalPosition; } set { } }
    public float HorizontalValue
    {
        get { return _horizontalValue; }
        set { _horizontalValue = Mathf.Clamp(value, -1f, 1f); }
    }
}
