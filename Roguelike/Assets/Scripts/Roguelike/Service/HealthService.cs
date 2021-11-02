using System;
using Roguelike.UI;
using UnityEngine;
using IngameDebugConsole;

namespace Roguelike.Service
{
    public class HealthService : MonoBehaviour
    {
        [SerializeField]
        private GameObject _otherGameObject;

        
        
        private static int _maxHealth = 100;
        private int _health = _maxHealth;
        
        private PlayerMovement _controls;
        private UIService _uiService;

        private HealthBar _healthBar;

        private void Awake()
        {
            _controls = _otherGameObject.GetComponent<PlayerMovement>();
            _uiService = GetComponent<UIService>();
            
            _healthBar = GetComponentInChildren<HealthBar>();
            _healthBar.UpdateBar((float)_maxHealth/100);
            
            DebugLogConsole.AddCommand("kill","kills player",Death);
        }

        public void IncreaseHealth(int health)
        {
            _health += health;
            if (_health > _maxHealth) _health = 100;
            _healthBar.UpdateBar((float)_health/100);
        }

        public void DecreaseHealth(int health)
        {
            _health -= health;
            if (_health <= 0)
            {
                _health = 0;
                Death();
            }
            _healthBar.UpdateBar((float)_health/100);
            
        }

        
        void Death()
        {
            _controls.enabled = false;
            Debug.Log("i dead");
            _uiService.CreatePrefabObject("UI/Game/DeathMenu/DeathMenu","MainScreen");
        }
        
    }
}