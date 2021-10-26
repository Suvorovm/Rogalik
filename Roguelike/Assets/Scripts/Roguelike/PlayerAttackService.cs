using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackService : MonoBehaviour
{
    public void Attack()
{
    GetComponent<PlayerCombat>().Attack(); 
}

public void Shoot()
{
   GetComponent<PlayerCombat>().DistanceAttack(); 
}
    
}
