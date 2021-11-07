using Core;
using Roguelike.Components;
using Roguelike.World.Service;
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
        private GameMasterService _gameMasterService;

        private void OnEnable()
        {
            HealthService.OnHealthUpdate += UpdateHealthBar;
            _pauseButton.onClick.AddListener(OnPauseButtonClick);
            _gameMasterService = GameApplication.RequireService<GameMasterService>();

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