using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using IngameDebugConsole;
using Roguelike.World;
using Roguelike.World.Service;
using UnityEngine;

public class HealObject : MonoBehaviour
{
    [SerializeField] private float _heal = 20.0f;

    private GameWorld _gameWorld;
    private HealthService _healthService;

    private void Awake()
    {
        _healthService = GameApplication.RequireService<HealthService>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collided");
        if (_healthService.Health != 100)
        {
            _healthService.IncreaseHealth(_heal);
            Debug.Log("Health picked up");
            _gameWorld.DestroyObjectByName(gameObject.name);
        }
    }
}