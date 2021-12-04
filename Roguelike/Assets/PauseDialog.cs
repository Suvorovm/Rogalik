using System.Collections;
using System.Collections.Generic;
using Core;
using Core.UI;
using Core.UI.Model;
using Roguelike.Service;
using UnityEngine;
using UnityEngine.UI;

public class PauseDialog : MonoBehaviour, IDialog
{
    public const string DIALOG_PATH = "UI/Game/Dialog/pfPauseDialog";
    [SerializeField]
    private Button _resumeButton;
    [SerializeField]
    private Button _menuButton;
    private UIService _uiService;
    private PauseService _pause;
    public void Configure(IDialogModel dialogModel)
    {
        _uiService = GameApplication.RequireService<UIService>();
        _resumeButton.onClick.AddListener(OnResumeButtonClick);
        _menuButton.onClick.AddListener(OnMenuButtonClick);
        _pause = GameApplication.RequireService<PauseService>();
        _pause.ChangePauseState();

    }

    private void OnMenuButtonClick()
    {
       GameApplication.Restart();
       Debug.Log("Проверка" );
       _pause.ChangePauseState();
    }

    private void OnResumeButtonClick()
    {
        _uiService.HideDialog(gameObject);
        _pause.ChangePauseState();
    }
}
