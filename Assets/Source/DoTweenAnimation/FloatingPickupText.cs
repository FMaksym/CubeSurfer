using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPickupText : MonoBehaviour
{
    [SerializeField] private float _yMoveDistance;
    [SerializeField] private float _floatDuration;

    private Tweener _textTween;

    private void OnEnable()
    {
        AnimateFloatingText();
    }

    public void AnimateFloatingText()
    {
        _textTween = transform.DOMoveY(transform.position.y + _yMoveDistance, _floatDuration)
                   .OnComplete(() => DeactivateText());
    }

    private void DeactivateText()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        _textTween.Kill();
    }
}
