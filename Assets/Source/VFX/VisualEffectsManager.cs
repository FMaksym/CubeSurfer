using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using Zenject;

public class VisualEffectsManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem _warpEffect;
    [SerializeField] private ParticleSystem _collectCubeEffect;
    [SerializeField] private CollectingTextsPool _collectTextsPool;

    [Inject] private Player _player;

    private void OnEnable()
    {
        GameManager.GameStartEvent += GameStarted;
        GameManager.BlockPickupEvent += PickupBlockEffect;
        GameManager.BlockPickupEvent += ActivatePickupingText;
        GameManager.GameOverEvent += GameOver;
    }

    private void Awake()
    {
        PlayWarpEffect(false);
    }

    private void PickupBlockEffect()
    {
        float newYPosition = _player._playerModel.transform.position.y - _player.transform.position.y;
        _collectCubeEffect.transform.position = new Vector3(_player.transform.position.x, newYPosition, _player.transform.position.z);
        _collectCubeEffect.Play();
    }

    private void ActivatePickupingText()
    {
        _collectTextsPool.ActivateText(_player._playerModel.transform.position);
    }

    private void GameStarted()
    {
        PlayWarpEffect(true);
    }

    private void GameOver()
    {
        PlayWarpEffect(false);
    }

    private void PlayWarpEffect(bool value)
    {
        if (value)
        {
            _warpEffect.Play();
        }
        else
        {
            _warpEffect.Stop();
        }
    }

    private void OnDisable()
    {
        GameManager.GameStartEvent -= GameStarted;
        GameManager.BlockPickupEvent -= PickupBlockEffect;
        GameManager.BlockPickupEvent -= ActivatePickupingText;
        GameManager.GameOverEvent -= GameOver;
    }
}
