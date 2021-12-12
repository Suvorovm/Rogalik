using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using Roguelike.World;
using UnityEngine;


public class EnemyController : MonoBehaviour
{
    [SerializeField] private float _enemyHP = 50f;
    [SerializeField] private Animator _animator;
    private GameWorld _gameWorld;
    private GameObject _enemy;
    private EnemyHealthService _enemyService;
    public void Awake()
    {
        _gameWorld = GameWorld.GameWorldInstance;
        _enemyService=GameApplication.RequireService<EnemyHealthService>();
        _enemyService.OnTakeDamage += OnTakeDamage;
    }

    public void OnTakeDamage(string id, float damage)
    {
        
        if (id == gameObject.name ) 
        {
            if (_enemyHP > 0)
            {
                _enemyHP -= damage;
                return;
            }
            else
            {
                OnDestroy();
                _gameWorld.DestroyObjectByName(gameObject.name); 
            }

            return;
        }
    }

    private void OnDestroy()
    
    {
        _enemyService.OnTakeDamage -= OnTakeDamage;
    }
} 