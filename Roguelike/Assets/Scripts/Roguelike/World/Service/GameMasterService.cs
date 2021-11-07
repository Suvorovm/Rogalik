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
        private void OnEnable()
        {
            _healthService = GameApplication.RequireService<HealthService>();
            _pauseService = GameApplication.RequireService<PauseService>();
        }
        
        public void PauseGame()
        {
            _pauseService.ChangePauseState();
        }
    }
}