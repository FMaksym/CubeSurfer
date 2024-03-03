using UnityEngine;

public class UIViewModel : MonoBehaviour
{
    [SerializeField] private UIView _view;
    [SerializeField] private UIModel _model;

    private void OnEnable()
    {
        GameManager.GameStartEvent += CloseMenuCanvas;
        GameManager.GameOverEvent += OpenGameCanvas;
    }

    public void OnClickPlayAgain()
    {
        _model.RestartLevel();
    }

    private void CloseMenuCanvas()
    {
        _model.ActivateDeactivateCanvas(_view.menuCanvas, false);
    }

    private void OpenGameCanvas()
    {
        _model.ActivateDeactivateCanvas(_view.gameCanvas, true);
    }

    private void OnDisable()
    {
        GameManager.GameStartEvent -= CloseMenuCanvas;
        GameManager.GameOverEvent -= OpenGameCanvas;
    }
}
