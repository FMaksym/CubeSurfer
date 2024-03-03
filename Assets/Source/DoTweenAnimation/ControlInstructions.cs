using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class ControlInstructions : MonoBehaviour
{
    [SerializeField] private Image handImage;
    [SerializeField] private TMP_Text textInstruction;

    private Tweener _imageScaleTween;
    private Tweener _imageMoveTween;
    private Tweener _textTween;

    void Start()
    {
        _imageScaleTween = handImage.transform.DOScale(1f, 0.8f).OnComplete(() => ImageMove());
        _textTween = textInstruction.transform.DOScale(1.2f, 0.8f).SetLoops(10000, LoopType.Yoyo).SetEase(Ease.InOutSine);
    }

    private void ImageMove()
    {
        handImage.transform.DOLocalMoveX(300f, 1f).SetLoops(10000, LoopType.Yoyo).SetEase(Ease.InOutSine);
    }

    private void OnDisable()
    {
        _imageScaleTween.Kill();
        _imageMoveTween.Kill();
        _textTween.Kill();
    }
}
