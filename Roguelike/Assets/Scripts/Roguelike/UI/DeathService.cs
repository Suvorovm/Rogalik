using System.Collections;
using System.Collections.Generic;
using Core;
using Core.UI;
using Roguelike.Service;
using Roguelike.UI;
using Roguelike.World.Service;
using UnityEngine;

public class DeathService : MonoBehaviour
{
    private UIService _uiService;
    private PauseService _pause;

    private void Awake()
    {
        HealthService.OnDeath += ShowDeathDialog;
        _uiService = GameApplication.RequireService<UIService>();
        _pause = GameApplication.RequireService<PauseService>();
    }

    private void ShowDeathDialog()
    {
        _pause.ChangePauseState();
        _uiService.ShowDialog<DeathDialog>(DeathDialog.DEATH_MENU_PATH);
    }
}