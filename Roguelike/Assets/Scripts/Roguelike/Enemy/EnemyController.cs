using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;


public class EnemyController : MonoBehaviour
{
    [SerializeField] private float _enemyHealth = 50f;
    [SerializeField]private Animator _animator;
    public void Awake()
    {
        EnemyHealthService enemyService = GameApplication.RequireService<EnemyHealthService>();
        enemyService.OnTakeDamage += OnTakeDamage;
    }

    public void OnTakeDamage(string id, float damage)
    {
        if (id != gameObject.name)
        {
            if (_enemyHealth > 0)
            {
                _enemyHealth -= damage;
            }
            else
            {

                Destroy(this.gameObject);
            }

            return;
        }
    }
    
}