using System;
using System.Collections;
using System.Collections.Generic;
using Roguelike.Service;
using TMPro;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private PlayerMovement _controls;

    private void Awake()
    {
        _controls = GetComponent<PlayerMovement>();
        
    }


    void Death()
    {
        _controls.enabled = false;
        

    }
}
