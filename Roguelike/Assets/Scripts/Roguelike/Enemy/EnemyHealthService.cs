using System;
using UnityEngine;
using System.Collections.Generic;

public class EnemyHealthService : MonoBehaviour
{
    public delegate void TakeDamage(string enemyId, float damage);

    public event Action<string, float> OnTakeDamage;

    public void DamageEnemy(string enemyId, float damage)
    {
        OnTakeDamage?.Invoke(enemyId, damage);
    }
}