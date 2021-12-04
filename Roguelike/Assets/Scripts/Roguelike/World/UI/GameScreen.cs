using Core;
using Core.UI;
using Core.UI.Model;
using Roguelike.UI;
using Roguelike.World.Player;
using Roguelike.World.Service;
using Roguelike.World.UI.Components;
using UnityEngine;
using UnityEngine.UI;

namespace Roguelike.World.UI
{
    public class GameScreen : MonoBehaviour, IScreen
    {
        public const string SCREEN_PATH = "UI/Game/Overlay/pfGameScreen";
        [SerializeField] private HealthBar _healthBar;
        [SerializeField] private Button _pauseButton;
        [SerializeField] private Button _attackButton;
        private PlayerAttackService _playerAttackService;
        private UIService _uiService;

        public void Configure(IScreenModel screenModel)
        {
            HealthService.OnHealthUpdate += UpdateHealthBar;
            _pauseButton.onClick.AddListener(OnPauseButtonClick);
            _playerAttackService = GameApplication.RequireService<PlayerAttackService>();
            _attackButton.onClick.AddListener(OnAttackButtonClick);
            _uiService = GameApplication.RequireService<UIService>();
        }

        private void OnAttackButtonClick()
        {
            _playerAttackService.Attack();
        }

        private void OnPauseButtonClick()
        {
            _uiService.ShowDialog<PauseDialog>(PauseDialog.DIALOG_PATH);;
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