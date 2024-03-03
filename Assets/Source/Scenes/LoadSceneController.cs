using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneController : MonoBehaviour
{
    [SerializeField] private float animationDuration = 1f;
    [SerializeField] private CanvasGroup _madeByText;

    private Tweener _tween;

    private void Awake()
    {
        if (_madeByText.alpha != 0)
        {
            _madeByText.alpha = 0;
        }
    }

    private void Start()
    {
        _tween = _madeByText.DOFade(1f, animationDuration).OnComplete(() => LoadNextScene());
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(1);
    }

    private void OnDisable()
    {
        _tween.Kill();
    }
}
