using Core;
using UnityEngine;

namespace Roguelike.World.Service
{
    public class HealthService : MonoBehaviour
    {
        public delegate void HealthUpdate(float health);

        public static event HealthUpdate OnHealthUpdate;
        
        public delegate void HealthDecrease(float damage);

        public static event HealthDecrease OnHealthDecrease;

        public delegate void Death();

        public static event Death OnDeath;

        private const float MAX_HEALTH = 100;
        private float _health;
        private float _damageTaken = 0f;

        private GameMasterService _gameMasterService;

        private void Awake()
        {
            _health = MAX_HEALTH;
            _gameMasterService = GameApplication.RequireService<GameMasterService>();
        }

        public void IncreaseHealth(float hp)
        {
            float deltaHealth = _health + hp;
            _health = deltaHealth >= MAX_HEALTH ? MAX_HEALTH : deltaHealth;
            OnHealthUpdate?.Invoke(_health);
        }

        public void DecreaseHealth(float hp)
        {
            _health -= hp;
            OnHealthDecrease?.Invoke(hp);
            if (_health > 0) {
                OnHealthUpdate?.Invoke(_health);
                
            } else {
                OnDeath?.Invoke();
                _health = 0;
                OnHealthUpdate?.Invoke(_health);
            }
        }

        public float Health
        {
            get { return _health; }
            set { _health = value; }
        }
    }
}