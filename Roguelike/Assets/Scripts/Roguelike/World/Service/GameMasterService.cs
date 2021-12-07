using System;
using Core;
using Roguelike.Service;
using UnityEngine;

namespace Roguelike.World.Service
{
    public class GameMasterService : MonoBehaviour
    {
        private HealthService _healthService;
        private PauseService _pauseService;
        private float stat;
        
        private void OnEnable()
        {
            _healthService = GameApplication.RequireService<HealthService>();
            _pauseService = GameApplication.RequireService<PauseService>();
            HealthService.OnHealthDecrease += CalculateDamage;
        }
        
        public void PauseGame()
        {
            _pauseService.ChangePauseState();
        }

        private void CalculateDamage(float damage)
        {
            DamageTaken = damage + DamageTaken;
        }
         public float DamageTaken
        {
            get {  return  stat; }
            set { stat = value; }
        }
    }
}