using UnityEngine;

namespace Roguelike
{
    public class HealthService :  HealthBar
    {
        public static int maxHealth = 100;
        private int _health = maxHealth;

        public void IncreaseHealth(int health)
        {
            _health += health;
            if (_health > maxHealth) _health = 1;
            UpdateBar(health/100);
        }

        public void DecreaseHealth(int health)
        {
            _health -= health;
            if (_health < 0) _health = 0;
            UpdateBar(health/100);
        }

    }
}