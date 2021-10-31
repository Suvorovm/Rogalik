using Core;
using UnityEngine;
using UnityEngine.UI;

namespace Roguelike.UI
{
    public class TestDialog : MonoBehaviour
    {
        [SerializeField]
        private Button _attackButton;
        [SerializeField]
        private Button _suckButton;
        private PlayerAttackService _playerAttackService;

        private void Awake()
        {
            _attackButton.onClick.AddListener(OnAttackButtonClick); 
            _suckButton.onClick.AddListener(OnSuckButtonClick);
            _playerAttackService = GameApplication.RequireService<PlayerAttackService>();
        }

        private void OnSuckButtonClick()
        {
            _playerAttackService.Shoot();
            
        }

        private void OnAttackButtonClick()
        {
            _playerAttackService.Attack();
        }
        
    }
}