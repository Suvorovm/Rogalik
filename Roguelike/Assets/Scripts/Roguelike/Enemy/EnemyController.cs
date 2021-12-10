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

    //private  EnemyHealthService _enemyService
    public void Awake()
    {
        _gameWorld = GameWorld.GameWorldInstance;
        EnemyHealthService
            enemyService =
                GameApplication
                    .RequireService<EnemyHealthService>(); // В поле класса, зачем постоянно дергать геймаппликешен _enemyService
        enemyService.OnTakeDamage += OnTakeDamage;
    }

    public void OnTakeDamage(string id, float damage)
    {
        _enemy = GameWorld.GameWorldInstance.RequaireObjectByName($"{id}"); // зачем брать из мира ??? и зачем строку оборачивать в строку  $"{id}" - это тоже самое, что  
        //GameWorld.GameWorldInstance.RequaireObjectByName(id);
        if (_enemy.name == gameObject.name &&
            _enemy != null) // gameObject.name == id Для этого и протаскивали сюда ID-к скрипт должен висеть там же где Id-к
            //ID - к должен быть униклаьным
        {
            if (_enemyHP > 0)
            {
                _enemyHP -= damage;
                return;
            }
            else
            {
                EnemyHealthService enemyService = GameApplication.RequireService<EnemyHealthService>();
                enemyService.OnTakeDamage -= OnTakeDamage; // Для таких целей у Unity Существует "Дестурктор"
                _gameWorld.DestroyObjectByName(_enemy.name); //gameObject.name
            }

            return;
        }
    }

    /*private void OnDestroy()
     //Дестурктор
    {
        throw new NotImplementedException();
    }*/
} //Тыкай чаще ctrl + alt + l пробелы, переносы и т.п расставленны  хаотично, сложно читать