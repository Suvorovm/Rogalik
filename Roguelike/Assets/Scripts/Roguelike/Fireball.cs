using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballDamagingExplosion : MonoBehaviour
{
    public GameObject explosionEffect;
    void OnTriggerEnter2D(Collider2D hitInfo )
    {
        //Enemy enemy = hitInfo.GetComponent<Enemy>();
        /*if (enemy != null)
        {
            Debug.Log("I blown up this fucker");
        }*/

        Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
    
}
