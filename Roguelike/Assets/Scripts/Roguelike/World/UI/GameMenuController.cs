using Core;
using Roguelike.World.Player;
using Roguelike.World.Service;
using Roguelike.World.UI.Components;
using UnityEngine;
using UnityEngine.UI;

namespace Roguelike.World.UI
{
    public class GameMenuController : MonoBehaviour
    {
        [SerializeField]
        private HealthBar _healthBar;
        [SerializeField]
        private Button _pauseButton;
        [SerializeField]
        private Button _attackButton;
        private PlayerAttackService _playerAttackService;
        private GameMasterService _gameMasterService;

        private void OnEnable()
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