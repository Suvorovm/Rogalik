using System;
using Core;
using Roguelike.UI;
using UnityEngine;
using IngameDebugConsole;

namespace Roguelike.Service
{
    public class HealthService : MonoBehaviour
    {
        [SerializeField] private GameObject _otherGameObject;


        private static int _maxHealth = 100;
        private int _health = _maxHealth;

        private PlayerMovement _controls;
        private CreateService _crService;

        private HealthBar _healthBar;

        // Путь к меню смерти
        private const string DEATH_MENU_PATH = "UI/Game/DeathMenu/DeathMenu";

        // Название объекта parent
        private const string UI_PARENT_NAME = "MainScreen";

        private void Awake()
        {
            _controls = _otherGameObject.GetComponent<PlayerMovement>();
            _crService = GameApplication.RequireService<CreateService>();

            _healthBar = GetComponentInChildren<HealthBar>();
            _healthBar.UpdateBar((float) _maxHealth / 100);

            DebugLogConsole.AddCommand("kill", "kills player", Death);
        }

        public void IncreaseHealth(int health)
        {
            _health += health;
            if (_health > _maxHealth) _health = 100;
            _healthBar.UpdateBar((float) _health / 100);
        }

        public void DecreaseHealth(int health)
        {
            _health -= health;
            if (_health <= 0)
            {
                _health = 0;
                Death();
            }

            _healthBar.UpdateBar((float) _health / 100);
        }


        void Death()
        {
            _controls.enabled = false;
            Debug.Log("i am dead");
            _crService.CreatePrefabObject(DEATH_MENU_PATH, UI_PARENT_NAME);
        }
    }
}