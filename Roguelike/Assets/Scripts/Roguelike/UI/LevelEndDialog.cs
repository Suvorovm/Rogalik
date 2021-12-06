using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using Core.UI;
using Core.UI.Model;
using Roguelike.World.Service;
using UnityEngine;
using UnityEngine.UI;

namespace Roguelike.UI
{
    public class LevelEndDialog : MonoBehaviour, IDialog
    {
        public const string DIALOG_PATH = "UI/Game/Dialog/LevelEndDialog/pfLevelEndDialog";

        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _nextLevelButton;

        [SerializeField] private Text _damageTaken;

        private LevelLoaderService _levelLoader;
        private UIService _uiService;
        private GameMasterService _gameMasterService;

        private void Awake()
        {
            _levelLoader = GameApplication.RequireService<LevelLoaderService>();
            _gameMasterService = GameApplication.RequireService<GameMasterService>();
            _uiService = GameApplication.RequireService<UIService>();
        }

        public void Configure(IDialogModel dialogModel)
        {
            _restartButton.onClick.AddListener(LevelRestart);
            _nextLevelButton.onClick.AddListener(LoadNextLevel);
            _damageTaken.text = "Damage taken:" + _gameMasterService.DamageTaken;
        }

        private void LevelRestart()
        {
            _levelLoader.LoadNextLevel(_levelLoader.CurentLevelNumber);
            _uiService.HideDialog<LevelEndDialog>();
           
        }

        private void LoadNextLevel()
        {
            _levelLoader.LoadNextLevel();
            _uiService.HideDialog<LevelEndDialog>();
          
        }

        private void GoToMainMenu()
        {
        }
    }
}