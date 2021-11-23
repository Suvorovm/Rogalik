using UnityEngine;

namespace Roguelike.World.Player
{
    public class PlayerAttackService : MonoBehaviour
    {
        private PlayerCombat _playerCombat;

        public void Awake()
        {
            _playerCombat = gameObject.GetComponentInChildren<PlayerCombat>();
        }

        public void Attack()
        {
            _playerCombat.Attack();
        }

        public void Shoot()
        {
            _playerCombat.DistanceAttack();
        }
    }
}