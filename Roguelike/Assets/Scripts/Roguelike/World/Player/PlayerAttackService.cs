using System;
using UnityEngine;

namespace Roguelike.World.Player
{
    public class PlayerAttackService : MonoBehaviour
    {
        private PlayerCombat _playerCombat;
        private GameWorld _gameWorld;
        private GameObject _player;
        

        public void Awake()
        {
            _gameWorld = GameWorld.GameWorldInstance;
            _gameWorld.OnInitialized += OnInitialized;
            
        }

        private void OnInitialized()
        {
            Debug.Log("World Created");
            //
            // _playerCombat = _gameWorld.GetComponentInWorld<PlayerCombat>();
            
        }
        private void OnDestroy()
        {
            _gameWorld.OnInitialized -= OnInitialized;
        }

        public void Attack()
        {
            _player = _gameWorld.RequaireObjectByName("Player");
            _playerCombat = _player.GetComponent<PlayerCombat>();
            _playerCombat.Attack();
        }


        public void Shoot()
        {
            _playerCombat.DistanceAttack();
        }
    }
}