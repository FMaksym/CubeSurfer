using UnityEngine;
using DG.Tweening;

public class UIElementActivate : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private float animationDuration = 1.0f;

    private Tweener _tween;

    private void Awake()
    {
        canvasGroup.alpha = 0f;
    }

    void Start()
    {
        _tween = canvasGroup.DOFade(1f, animationDuration);
    }

    private void OnDisable()
    {
        _tween.Kill();
    }
}
