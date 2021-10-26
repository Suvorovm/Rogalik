using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    private PlayerAttackService _playerAttackService;
    public void Awake(){
        _playerAttackService = application.Require<PlayerAttackService>();
    }

    public void OnAttackButtonClick(){
        _playerAttackService.Attack();
    }
    public void OnAttackButtonClick2(){
        _playerAttackService.Shoot();
    }

}


