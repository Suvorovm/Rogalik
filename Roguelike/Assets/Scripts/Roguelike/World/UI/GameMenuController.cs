﻿using Core;
using Core.UI;
using Core.UI.Model;
using Roguelike.Components;
using Roguelike.World.Service;
using UnityEngine;
using UnityEngine.UI;

namespace Roguelike.World.UI
{
    public class GameMenuController : MonoBehaviour, IScreen
    {
        public const string SCREEN_PATH = "UI/Game/Overlay/pfGameOverlay";
        [SerializeField] private HealthBar _healthBar;
        [SerializeField] private Button _pauseButton;
        [SerializeField] private Button _attackButton;
        private PlayerAttackService _playerAttackService;
        private GameMasterService _gameMasterService;

        public void Configure(IScreenModel screenModel)
        {
            HealthService.OnHealthUpdate += UpdateHealthBar;
            _pauseButton.onClick.AddListener(OnPauseButtonClick);
            _gameMasterService = GameApplication.RequireService<GameMasterService>();
            _playerAttackService = GameApplication.RequireService<PlayerAttackService>();
            _attackButton.onClick.AddListener(OnAttackButtonClick);
        }

        private void OnAttackButtonClick()
        {
            _playerAttackService.Attack();
        }

        private void OnPauseButtonClick()
        {
            _gameMasterService.PauseGame();
        }

        private void UpdateHealthBar(float health)
        {
            _healthBar.UpdateBar(health / 100);
        }

        private void OnDisable()
        {
            HealthService.OnHealthUpdate -= UpdateHealthBar;
        }
    }
}