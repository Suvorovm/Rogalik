using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using Core.UI;
using Roguelike.Service;
using Roguelike.UI;
using UnityEngine;

public class LevelEndTriger : MonoBehaviour
{
    private UIService _uiService;
    private PauseService _pause;
    private void Awake()
    {
        _uiService = GameApplication.RequireService<UIService>();
        _pause = GameApplication.RequireService<PauseService>();
        Debug.Log("11");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collided");
        _pause.ChangePauseState();
        _uiService.ShowDialog<LevelEndDialog>(LevelEndDialog.DIALOG_PATH);
    }
}
