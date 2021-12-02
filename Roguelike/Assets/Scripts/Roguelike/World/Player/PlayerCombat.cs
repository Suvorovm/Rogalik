using System;
using Core;
using UnityEngine;

namespace Roguelike.World.Player
{
    public class PlayerCombat : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private Transform AttackPoint;
        [SerializeField] private float _attackRange = 0.5f;
        [SerializeField] private Transform abilityStPoint;
        [SerializeField] private float _fireballspeed = 10f;
        [SerializeField] private float _playerDamage = 15f;
        public LayerMask enemyLayers;
        public GameObject fireballPrefab;
        private EnemyHealthService _enemyHealth;

        private void Awake()
        {
            _enemyHealth = GameApplication.RequireService<EnemyHealthService>();
        }

        public void Attack()
        {
            Debug.Log("Try attack");
            _animator.SetTrigger("Attack");
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, _attackRange, enemyLayers);
            foreach (Collider2D enemy in hitEnemies) {
                _enemyHealth.DamageEnemy("{enemy.name}",_playerDamage);
                Debug.Log("I hit this fucker" + enemy.name);
            }
        }

        public void DistanceAttack()
        {
            GameObject fireball = Instantiate(fireballPrefab, abilityStPoint.position, abilityStPoint.rotation);
            Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();
            rb.AddForce(abilityStPoint.up * _fireballspeed, ForceMode2D.Impulse);
        }
    }
}