using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Animator animator;
    private float _enemyHealth;

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

