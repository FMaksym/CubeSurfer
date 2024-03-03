using System.Threading.Tasks;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField, Min(0)] private int shakeCount = 1;
    [SerializeField] private float shakeIntensity = 0.15f;
    [SerializeField, Min(0)] private float shakeDelay;

    private Quaternion originalRotation;

    private void OnEnable()
    {
        GameManager.CollisionWithObstacleEvent += ShakeCameraRepeatedly;
    }

    private void Start()
    {
        originalRotation = transform.rotation;
    }

    private async void ShakeCameraRepeatedly()
    {
        for (int i = 0; i < shakeCount; i++)
        {
            ShakeCamera(shakeIntensity);
            await Task.Delay(25);
            ShakeCamera(-shakeIntensity);
        }
        transform.rotation = originalRotation;
    }

    private void ShakeCamera(float shakeIntensity)
    {
        Quaternion targetRotation = Quaternion.Euler(originalRotation.eulerAngles + new Vector3(0, shakeIntensity, 0));
        transform.rotation = targetRotation;
        transform.Rotate(Vector3.up, shakeIntensity);
    }

    private void OnDisable()
    {
        GameManager.CollisionWithObstacleEvent -= ShakeCameraRepeatedly;
    }
}
