using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackSpawn : MonoBehaviour
{
    [SerializeField] private float _startYPosition;
    [SerializeField] private float _endYPosition;
    [SerializeField] private float _floatDuration;

    private Tweener _tween;

    private void OnEnable()
    {
        transform.position = new Vector3(transform.position.x, _startYPosition, transform.position.z );
        RoadMove();
    }

    public void RoadMove()
    {
        _tween = transform.DOMoveY(_endYPosition, _floatDuration);
    }

    private void OnDisable()
    {
        _tween.Kill();
    }
}
