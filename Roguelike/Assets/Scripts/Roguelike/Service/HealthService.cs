using Roguelike.UI;
using UnityEngine;

namespace Roguelike.Service
{
    public class HealthService : MonoBehaviour
    {
        private static int _maxHealth = 100;
        private int _health = _maxHealth;

        private HealthBar _healthBar;

        private void Awake()
        {
            _healthBar = GetComponentInChildren<HealthBar>();
            _healthBar.UpdateBar((float)_maxHealth/100);
        }

        public void IncreaseHealth(int health)
        {
            _health += health;
            if (_health > _maxHealth) _health = 100;
            _healthBar.UpdateBar(_health);
        }

        public void DecreaseHealth(int health)
        {
            _health -= health;
            if (_health < 0) _health = 0;
            _healthBar.UpdateBar((float)_health/100);
        }
    }
}