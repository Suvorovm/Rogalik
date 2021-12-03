using System;
using UnityEngine;
using System.Collections.Generic;
using Core;

public class EnemyHealthService : MonoBehaviour
{
    public event Action<string, float> OnTakeDamage;

    public void DamageEnemy(string enemyId, float damage)
    {
        OnTakeDamage?.Invoke(enemyId, damage);
    }
}