using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using Roguelike.World;
using UnityEngine;


public class EnemyController : MonoBehaviour
{
    [SerializeField] private float _enemyHP = 50f;
    [SerializeField]private Animator _animator;
    private GameWorld _gameWorld;
    private GameObject _enemy;
    public void Awake()
    {
        
        _gameWorld=GameWorld.GameWorldInstance;
        EnemyHealthService enemyService = GameApplication.RequireService<EnemyHealthService>();
        enemyService.OnTakeDamage += OnTakeDamage;
    }

    public void OnTakeDamage(string id, float damage)
    {
        _enemy = GameWorld.GameWorldInstance.RequaireObjectByName($"{id}");
        if ( _enemy.name==gameObject.name && _enemy!= null)
        {
            if (_enemyHP > 0)
            {
               _enemyHP -= damage;
                return;
            }
            else
            {
                EnemyHealthService enemyService = GameApplication.RequireService<EnemyHealthService>();
                enemyService.OnTakeDamage -= OnTakeDamage;
                _gameWorld.DestroyObjectByName(_enemy.name);
            }

            return;
        }
        
    }
    
}