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
    public void Awake()
    {
        EnemyHealthService enemyService = GameApplication.RequireService<EnemyHealthService>();
        enemyService.OnTakeDamage += OnTakeDamage;
    }

    public void OnTakeDamage(string id, float damage)
    {
        if (id != gameObject.name)
        {
            if (_enemyHP > 0)
            {
                _enemyHP -= damage;
            }
            else
            {
                _gameWorld.DestroyObjectByName(gameObject.name);
            }

            return;
        }
    }
    
}